using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace HospitalSeleniumTests.Pages
{
    public class AddNewOnCallShiftPage
    {
        private readonly IWebDriver driver;
        public const string URI = "http://localhost:4200/new-on-call-shift/3";

        private IWebElement NextButton => driver.FindElement(By.Id("next1"));
        private ReadOnlyCollection<IWebElement> RowsOfFreeTerms => driver.FindElements(By.XPath("//table[@id='freeterms']/tbody/tr"));
        private IWebElement InputElement => driver.FindElement(By.Id("1"));
        private IWebElement AddShiftButton => driver.FindElement(By.Id("addshift"));

        public AddNewOnCallShiftPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void EnsureFreeTermsTabelLabelIsDisplayed()
        {
            var wait = new WebDriverWait(driver, new TimeSpan(0, 0, 40));
            wait.Until(condition =>
            {
                try
                {
                    return RowsOfFreeTerms.Count > 0;
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

        public void ClickOnNextButton()
        {
            NextButton.Click();
        }

        public void ClickOnRadioInput()
        {
            InputElement.Click();
        }

        public void ClickOnAddButton()
        {
            AddShiftButton.Click();
        }

        public bool NextButtonDisplayed()
        {
            return NextButton.Displayed;
        }

        public bool InputElementDisplayed()
        {
            return InputElement.Displayed;
        }

        public bool AddShiftButtonDisplayed()
        {
            return AddShiftButton.Displayed;
        }

        public void Navigate() => driver.Navigate().GoToUrl(URI);

        public void WaitForListingFreeTerms()
        {
            var wait = new WebDriverWait(driver, new TimeSpan(0, 0, 40));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//*[@id='freeterms']")));
        }

    }
}
