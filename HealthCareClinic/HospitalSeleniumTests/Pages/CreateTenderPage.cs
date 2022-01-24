using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace HospitalSeleniumTests.Pages
{
    public class CreateTenderPage
    {
        private readonly IWebDriver _driver;
        public const string URI = "http://localhost:4200/create-tender";
        private IWebElement StartDateElement => _driver.FindElement(By.Id("startDate"));
        private IWebElement EndDateElement => _driver.FindElement(By.Id("endDate"));
        private IWebElement DescriptionElement => _driver.FindElement(By.Id("description"));
        private IWebElement MedicineNameElement => _driver.FindElement(By.Id("medicineName"));
        private IWebElement QuantityElement => _driver.FindElement(By.Id("quantity"));
        private IWebElement SubmitButtonElement => _driver.FindElement(By.Id("submitTender"));
        private IWebElement AddMedicineButtonElement => _driver.FindElement(By.Id("add-button"));
        public string Title => _driver.Title;
        public const string MissingDescriptionMessage = "Please enter tender description!";
        public const string MissingMedicineNameMessage = "Please enter medicine name!";
        public const string MissingMedicineQuantityMessage = "Please enter medicine quantity!";
        public const string SuccessMessage = "Tender has been created successfully!";

        public CreateTenderPage(IWebDriver driver)
        {
            _driver = driver;
        }

        public void EnsureButtonIsDisplayed()
        {
            var wait = new WebDriverWait(_driver, new TimeSpan(0, 0, 30));
            wait.Until(condition =>
            {
                try
                {
                    return SubmitButtonElementDisplayed();
                }
                catch (StaleElementReferenceException)
                {
                    return false;
                }
                catch (NoSuchElementException)
                {
                    return false;
                }
            });
        }

        public bool SubmitButtonElementDisplayed()
        {
            return SubmitButtonElement.Displayed;
        }

        public bool StartDateElementDisplayed()
        {
            return StartDateElement.Displayed;
        }

        public bool EndDateElementDisplayed()
        {
            return EndDateElement.Displayed;
        }

        public bool DescriptionElementDisplayed()
        {
            return DescriptionElement.Displayed;
        }

        public bool MedicineNameElementDisplayed()
        {
            return MedicineNameElement.Displayed;
        }

        public bool QuantityElementDisplayed()
        {
            return QuantityElement.Displayed;
        }

        public bool AddMedicineButtonDisplayed()
        {
            return AddMedicineButtonElement.Displayed;
        }

        public void InsertStartDate(string startDate)
        {
            StartDateElement.SendKeys(startDate);
        }

        public void InsertEndDate(string endDate)
        {
            EndDateElement.SendKeys(endDate);
        }

        public void InsertDescription(string description)
        {
            DescriptionElement.SendKeys(description);
        }

        public void InsertMedicineName(string name)
        {
            MedicineNameElement.SendKeys(name);
        }

        public void InsertQuantity(string quantity)
        {
            QuantityElement.SendKeys(quantity);
        }

        public void CreateTender()
        {
            SubmitButtonElement.Click();
        }

        public void AddMedicine()
        {
            AddMedicineButtonElement.Click();
        }

        public void WaitForFormSubmit()
        {
            var wait = new WebDriverWait(_driver, new TimeSpan(0, 0, 20));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.UrlToBe(HomePage.URI));
        }

        public void WaitForAlertDialog()
        {
            var wait = new WebDriverWait(_driver, new TimeSpan(0, 0, 10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.AlertIsPresent());
        }

        public string GetDialogMessage()
        {
            return _driver.SwitchTo().Alert().Text;
        }

        public void ResolveAlertDialog()
        {
            _driver.SwitchTo().Alert().Accept();
        }

        public void Navigate() => _driver.Navigate().GoToUrl(URI);
    }
}
