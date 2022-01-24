using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace HospitalSeleniumTests.Pages
{
    public class OnCallShiftsPage
    {
        private readonly IWebDriver driver;
        public const string URI = "http://localhost:4200/on-call-shifts/3";
        public ReadOnlyCollection<IWebElement> RowsOfShifts => driver.FindElements(By.XPath("//table[@id='shifts']/tbody/tr"));
        private IWebElement AddNewOnCallShiftButton => driver.FindElement(By.Id("add-new-on-call-shift"));

        public OnCallShiftsPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void EnsureShiftsTabelLabelIsDisplayed()
        {
            var wait = new WebDriverWait(driver, new TimeSpan(0, 0, 20));
            wait.Until(condition =>
            {
                try
                {
                    return RowsOfShifts.Count > 0;
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

        public bool AddNewOnCallShiftButtonDisplayed()
        {
            return AddNewOnCallShiftButton.Displayed;
        }

        public void ClickOnAddNewOnCallShift()
        {
            AddNewOnCallShiftButton.Click();
        }

        public void Navigate() => driver.Navigate().GoToUrl(URI);


        public void WaitForListingShifts()
        {
            var wait = new WebDriverWait(driver, new TimeSpan(0, 0, 40));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//*[@id='shifts']")));
        }
    }
}
