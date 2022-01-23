using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Xunit;

namespace HospitalSeleniumTests
{
    public class UrgentMedicinesGrpcTests : IDisposable
    {
        private readonly IWebDriver _driver;
        private Pages.UrgentProcurementPage urgentProcurementPage;
        private Pages.LoginPage loginPage;

        public UrgentMedicinesGrpcTests()
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
        public void TestInvalidMedicineName()
        {
            urgentProcurementPage.InsertMedicineName("");
            urgentProcurementPage.InsertMedicineAmount("213.4");
            urgentProcurementPage.OrderMedicine();

            urgentProcurementPage.WaitForAlertDialog();
            Assert.Equal(urgentProcurementPage.GetDialogMessage(), Pages.UrgentProcurementPage.InvalidMedicineNameMessage);
            urgentProcurementPage.ResolveAlertDialog();
            Assert.Equal(_driver.Url, Pages.UrgentProcurementPage.URI);
        }

        [Fact]
        public void TestInvalidMedicineAmount()
        {
            urgentProcurementPage.InsertMedicineName("Brufen");
            urgentProcurementPage.InsertMedicineAmount("");
            urgentProcurementPage.OrderMedicine();

            urgentProcurementPage.WaitForAlertDialog();
            Assert.Equal(urgentProcurementPage.GetDialogMessage(), Pages.UrgentProcurementPage.InvalidMedicineAmountMessage);
            urgentProcurementPage.ResolveAlertDialog();
            Assert.Equal(_driver.Url, Pages.UrgentProcurementPage.URI);
        }

        [Fact]
        public void TestMedicineAmountIsNaN()
        {
            urgentProcurementPage.InsertMedicineName("Brufen");
            urgentProcurementPage.InsertMedicineAmount("asd");
            urgentProcurementPage.OrderMedicine();

            urgentProcurementPage.WaitForAlertDialog();
            Assert.Equal(urgentProcurementPage.GetDialogMessage(), Pages.UrgentProcurementPage.MedicineAmountIsNaNMessage);
            urgentProcurementPage.ResolveAlertDialog();
            Assert.Equal(_driver.Url, Pages.UrgentProcurementPage.URI);
        }

        [Fact]
        public void TestMedicineNotFound()
        {
            urgentProcurementPage.InsertMedicineName("asd");
            urgentProcurementPage.InsertMedicineAmount("2");
            urgentProcurementPage.OrderMedicine();

            urgentProcurementPage.WaitForAlertDialog();
            Assert.Equal(urgentProcurementPage.GetDialogMessage(), Pages.UrgentProcurementPage.MedicineNotFoundMessage("asd"));
            urgentProcurementPage.ResolveAlertDialog();
            Assert.Equal(_driver.Url, Pages.UrgentProcurementPage.URI);
        }

        [Fact]
        public void TestMedicineAmountIsLessThenRequested()
        {
            urgentProcurementPage.InsertMedicineName("Brufen");
            urgentProcurementPage.InsertMedicineAmount("1000");
            urgentProcurementPage.OrderMedicine();

            urgentProcurementPage.WaitForAlertDialog();
            Assert.Equal(urgentProcurementPage.GetDialogMessage(), Pages.UrgentProcurementPage.MedicineAmountIsLessThenRequestedMessage("Brufen", 1000));
            urgentProcurementPage.ResolveAlertDialog();
            Assert.Equal(_driver.Url, Pages.UrgentProcurementPage.URI);
        }

        [Fact]
        public void TestSuccessfulSubmit()
        {
            urgentProcurementPage.InsertMedicineName("Brufen");
            urgentProcurementPage.InsertMedicineAmount("2");
            urgentProcurementPage.OrderMedicine();

            urgentProcurementPage.WaitForAlertDialog();
            Assert.Equal(urgentProcurementPage.GetDialogMessage(), Pages.UrgentProcurementPage.MedicineTransferedMessage("Brufen", 2));
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
