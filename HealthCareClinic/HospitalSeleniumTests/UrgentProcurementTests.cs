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

            urgentProcurementPage = new Pages.UrgentProcurementPage(_driver);
            urgentProcurementPage.Navigate();
            

            Assert.Equal(_driver.Url, Pages.CreateTenderPage.URI);

            Assert.True(urgentProcurementPage.MedicineNameDisplayed());
            Assert.True(urgentProcurementPage.MedicineAmountDisplayed());
        }

        [Fact]
        public void SuccessfulSubmit()
        {
            Assert.True(urgentProcurementPage.MedicineNameDisplayed());
            Assert.True(urgentProcurementPage.MedicineAmountDisplayed());
        }

        public void Dispose()
        {
            _driver.Quit();
            _driver.Dispose();
        }
    }
}

