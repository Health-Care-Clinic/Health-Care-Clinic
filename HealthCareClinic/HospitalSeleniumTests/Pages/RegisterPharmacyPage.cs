using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace HospitalSeleniumTests.Pages
{
    class RegisterPharmacyPage
    {
        private readonly IWebDriver _driver;
        public const string URI = "http://localhost:4200/registration";
        private IWebElement PharmacyNameElement => _driver.FindElement(By.Id("name"));
        private IWebElement UrlElement => _driver.FindElement(By.Id("ph-url"));
        private IWebElement RegisterButtonElement => _driver.FindElement(By.Id("register-btn"));
        public string Title => _driver.Title;
        public const string MissingInputMessage = "Please fill out all fields.";
        public const string InvalidUrlMessage = "Please enter valid URL.";
        public const string SuccessMessage = "Sucessfully registrated.";
        public const string UnsuccessMessage = "Unsuccesful registration.";

        public RegisterPharmacyPage(IWebDriver driver)
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
                    return RegisterButtonElementDisplayed();
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

        public bool RegisterButtonElementDisplayed()
        {
            return RegisterButtonElement.Displayed;
        }

        public bool UrlElementDisplayed()
        {
            return UrlElement.Displayed;
        }

        public bool PharmacyNameElementDisplayed()
        {
            return PharmacyNameElement.Displayed;
        }

        public void InsertUrl(string url)
        {
            UrlElement.SendKeys(url);
        }

        public void InsertPharmacyName(string name)
        {
            PharmacyNameElement.SendKeys(name);
        }
        public void RegisterPharmacy()
        {
            RegisterButtonElement.Click();
        }



        //?????????????
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
