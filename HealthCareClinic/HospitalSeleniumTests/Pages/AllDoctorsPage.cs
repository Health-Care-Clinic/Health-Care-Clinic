using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace HospitalSeleniumTests.Pages
{
    public class AllDoctorsPage
    {
        private readonly IWebDriver driver;
        public const string URI = "http://localhost:4200/doctors";
        private ReadOnlyCollection<IWebElement> RowsOfDoctors => driver.FindElements(By.XPath("//table[@id='doctors']/tbody/tr"));
        private IWebElement OnCallShiftButton => driver.FindElement(By.XPath("//table[@id='doctors']/tbody/tr[last()]/td[3]"));

        public AllDoctorsPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void EnsureDoctorsTabelLabelIsDisplayed()
        {
            var wait = new WebDriverWait(driver, new TimeSpan(0, 0, 10));
            wait.Until(condition =>
            {
                try
                {
                    return RowsOfDoctors.Count > 0;
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

        public bool OnCallShiftButtonDisplayed()
        {
            return OnCallShiftButton.Displayed;
        }

        public void ClickOnOnCallShifts()
        {
            OnCallShiftButton.Click();
        }

        public void Navigate() => driver.Navigate().GoToUrl(URI);

        public void WaitForListingDoctors()
        {
            var wait = new WebDriverWait(driver, new TimeSpan(0, 0, 20));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//*[@id='doctors']")));
        }

    }
  
}
