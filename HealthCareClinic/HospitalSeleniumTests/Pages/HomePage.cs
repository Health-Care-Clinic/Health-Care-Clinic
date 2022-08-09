using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace HospitalSeleniumTests.Pages
{
    public class HomePage
    {
        private readonly IWebDriver driver;
        public const string URI = "http://localhost:4200/hospital-map";
        private IWebElement BlockPatientsButtonElement => driver.FindElement(By.Id("blockPatient"));
        public string Title => driver.Title;


        public void EnsureButtonIsDisplayed()
        {
            var wait = new WebDriverWait(driver, new TimeSpan(0, 0, 30));
            wait.Until(condition =>
            {
                try
                {
                    return BlockPatientsButtonElementDisplayed();
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

        public bool BlockPatientsButtonElementDisplayed()
        {
            return BlockPatientsButtonElement.Displayed;
        }        

        public void ClickOnBlocking()
        {
            BlockPatientsButtonElement.Click();
        }

        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void WaitForListingMalicious()
        {
            var wait = new WebDriverWait(driver, new TimeSpan(0, 0, 10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.UrlToBe(MaliciousPatientsPage.URI));
        }

        public void Navigate() => driver.Navigate().GoToUrl(URI);
    }
}
