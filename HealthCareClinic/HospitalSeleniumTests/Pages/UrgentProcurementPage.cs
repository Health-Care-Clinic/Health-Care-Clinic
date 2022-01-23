using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace HospitalSeleniumTests.Pages
{
    public class UrgentProcurementPage
    {
        private readonly IWebDriver _driver;
        public const string URI = "http://localhost:4200/urgent-procurement";
        private IWebElement MedicineName => _driver.FindElement(By.Id("medicineName"));
        private IWebElement MedicineAmount => _driver.FindElement(By.Id("medicineAmount"));
        public string Title => _driver.Title;

        public UrgentProcurementPage(IWebDriver driver)
        {
            _driver = driver;
        }

        public bool MedicineNameDisplayed()
        {
            return MedicineName.Displayed;
        }

        public bool MedicineAmountDisplayed()
        {
            return MedicineAmount.Displayed;
        }
        

        public void Wait()
        {
            var wait = new WebDriverWait(_driver, new TimeSpan(0, 0, 20));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.UrlToBe(HomePage.URI));
        }

        public void Navigate() => _driver.Navigate().GoToUrl(URI);
    }
}

