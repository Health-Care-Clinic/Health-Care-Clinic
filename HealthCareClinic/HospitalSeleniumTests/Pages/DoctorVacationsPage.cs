using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace HospitalSeleniumTests.Pages
{
    public class DoctorVacationsPage
    {
        private readonly IWebDriver driver;
        public const string URI = "http://localhost:4200/doctor-vacations/3";
        public ReadOnlyCollection<IWebElement> RowsOfPastVacations => driver.FindElements(By.XPath("//table[@id='pastVacations']/tbody/tr"));
        public ReadOnlyCollection<IWebElement> RowsOfCurrentVacations => driver.FindElements(By.XPath("//table[@id='currentVacations']/tbody/tr"));
        public ReadOnlyCollection<IWebElement> RowsOfFutureVacations => driver.FindElements(By.XPath("//table[@id='futureVacations']/tbody/tr"));
        private IWebElement ScheduleVacationButton => driver.FindElement(By.Id("scheduleVacationButtonId"));

        public DoctorVacationsPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void EnsurePastVacationsTabelLabelIsDisplayed()
        {
            var wait = new WebDriverWait(driver, new TimeSpan(0, 0, 50));
            wait.Until(condition =>
            {
                try
                {
                    return RowsOfPastVacations.Count >= 0;
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

        public void EnsureCurrentVacationsTabelLabelIsDisplayed()
        {
            var wait = new WebDriverWait(driver, new TimeSpan(0, 0, 50));
            wait.Until(condition =>
            {
                try
                {
                    return RowsOfCurrentVacations.Count >= 0;
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

        public void EnsureFutureVacationsTabelLabelIsDisplayed()
        {
            var wait = new WebDriverWait(driver, new TimeSpan(0, 0, 50));
            wait.Until(condition =>
            {
                try
                {
                    return RowsOfFutureVacations.Count >= 0;
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

        public bool ScheduleVacationsButtonDisplayed()
        {
            return ScheduleVacationButton.Displayed;
        }

        public void ClickOnScheduleVacation()
        {
            ScheduleVacationButton.Click();
        }

        public void WaitForListingPastVacations()
        {
            var wait = new WebDriverWait(driver, new TimeSpan(0, 0, 50));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//*[@id='pastVacations']")));
        }

        public void WaitForListingCurrentVacations()
        {
            var wait = new WebDriverWait(driver, new TimeSpan(0, 0, 50));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//*[@id='currentVacations']")));
        }

        public void WaitForListingFutureVacations()
        {
            var wait = new WebDriverWait(driver, new TimeSpan(0, 0, 50));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//*[@id='futureVacations']")));
        }
    }
}
