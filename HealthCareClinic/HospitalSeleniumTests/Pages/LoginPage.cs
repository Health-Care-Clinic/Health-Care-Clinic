using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace HospitalSeleniumTests.Pages
{
    public class LoginPage
    {
        private readonly IWebDriver driver;
        public const string URI = "http://localhost:4200/login";
        private IWebElement UsernameElement => driver.FindElement(By.Id("username"));
        private IWebElement PasswordElement => driver.FindElement(By.Id("password"));
        private IWebElement SubmitButtonElement => driver.FindElement(By.Id("submit"));
        public string Title => driver.Title;


        public void EnsureButtonIsDisplayed()
        {
            var wait = new WebDriverWait(driver, new TimeSpan(0, 0, 30));
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

        public bool UsernameElementDisplayed()
        {
            return UsernameElement.Displayed;
        }

        public bool PasswordElementDisplayed()
        {
            return PasswordElement.Displayed;
        }

        public bool SubmitButtonElementDisplayed()
        {
            return SubmitButtonElement.Displayed;
        }

        public void InsertUsername(string name)
        {
            UsernameElement.SendKeys(name);
        }

        public void InsertPassword(string name)
        {
            PasswordElement.SendKeys(name);
        }

        public void SubmitForm()
        {
            SubmitButtonElement.Click();
        }

        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void WaitForFormSubmit()
        {
            var wait = new WebDriverWait(driver, new TimeSpan(0, 0, 20));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.UrlToBe(HomePage.URI));
        }


        public void Navigate() => driver.Navigate().GoToUrl(URI);
    }
}
