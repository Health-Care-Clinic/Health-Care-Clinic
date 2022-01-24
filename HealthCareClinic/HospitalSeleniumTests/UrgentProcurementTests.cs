using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Xunit;

namespace HospitalSeleniumTests
{
    public class UrgentProcurementTests : IDisposable
    {
        private readonly IWebDriver _driver;
        private Pages.UrgentProcurementPage urgentProcurementPage;
        private Pages.LoginPage loginPage;

        public UrgentProcurementTests()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArguments("start-maximized");
            options.AddArguments("disable-infobars");
            options.AddArguments("--disable-extensions");
            options.AddArguments("--disable-gpu");
            options.AddArguments("--disable-dev-shm-usage");
            options.AddArguments("--no-sandbox");
            options.AddArguments("--disable-notifications");

            _driver = new ChromeDriver(options);

            loginPage = new Pages.LoginPage(_driver);
            loginPage.Navigate();
            loginPage.EnsureButtonIsDisplayed();
            loginPage.InsertUsername("admin");
            loginPage.InsertPassword("admin");
            loginPage.SubmitForm();
            loginPage.WaitForFormSubmit();

            urgentProcurementPage = new Pages.UrgentProcurementPage(_driver);
            urgentProcurementPage.Navigate();
            urgentProcurementPage.EnsurePageIsDisplayed();

            Assert.Equal(_driver.Url, Pages.UrgentProcurementPage.URI);

            Assert.True(urgentProcurementPage.MedicineNameDisplayed());
            Assert.True(urgentProcurementPage.MedicineAmountDisplayed());
            Assert.True(urgentProcurementPage.OrderMedicineButtonDisplayed());
        }

        [Fact]
        public void TestSuccessfulSubmit()
        {
            urgentProcurementPage.InsertMedicineName("Brufen");
            urgentProcurementPage.InsertMedicineAmount("2");
            urgentProcurementPage.CheckMedicine();
            urgentProcurementPage.Order();

            urgentProcurementPage.WaitForAlertDialog();
            Assert.Equal(urgentProcurementPage.GetDialogMessage(), Pages.UrgentProcurementPage.SuccessMessage());
            urgentProcurementPage.ResolveAlertDialog();
            Assert.Equal(_driver.Url, Pages.UrgentProcurementPage.URI);
        }

        [Fact]
        public void TestUnsuccessfulSubmit()
        {
            urgentProcurementPage.InsertMedicineName("Brufen");
            urgentProcurementPage.InsertMedicineAmount("20000000");
            urgentProcurementPage.CheckMedicine();

            urgentProcurementPage.WaitForAlertDialog();
            Assert.Equal(urgentProcurementPage.GetDialogMessage(), Pages.UrgentProcurementPage.OrderError());
            urgentProcurementPage.ResolveAlertDialog();
            Assert.Equal(_driver.Url, Pages.UrgentProcurementPage.URI);
        }

        public void Dispose()
        {
            _driver.Quit();
            _driver.Dispose();
        }
    }
}

