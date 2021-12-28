using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace HospitalSeleniumTests.Pages
{
    public class MaliciousPatientsPage
    {
        private readonly IWebDriver driver;
        public const string URI = "http://localhost:4200/malicious-patients";
        private IWebElement Table => driver.FindElement(By.Id("maliciousPatients"));
        //private ReadOnlyCollection<IWebElement> Rows => driver.FindElements(By.XPath("//table[@id='maliciousPatients']/tbody/tr"));

        //private IWebElement LastRowName => driver.FindElement(By.XPath("//table[@id='maliciousPatients']/tbody/tr[last()]/td[1]"));
        //private IWebElement LastRowColor => driver.FindElement(By.XPath("//table[@id='maliciousPatients']/tbody/tr[last()]/td[2]"));
        //private IWebElement LastRowPrice => driver.FindElement(By.XPath("//table[@id='maliciousPatients']/tbody/tr[last()]/td[3]"));
        private IWebElement ButtonBlock => driver.FindElement(By.Id("1"));
        public string Title => driver.Title;
        public void EnsureButtonIsDisplayed()
        {
            var wait = new WebDriverWait(driver, new TimeSpan(0, 0, 30));
            wait.Until(condition =>
            {
                try
                {
                    return LinkDisplayed();
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

        public void EnsureButtonIsNotDisplayed()
        {
            var wait = new WebDriverWait(driver, new TimeSpan(0, 0, 10));
            wait.Until(condition =>
            {
                try
                {
                    IWebElement ButtonBlockVanished = driver.FindElement(By.Id("1"));
                    return !ButtonBlockVanished.Displayed;
                }
                catch (StaleElementReferenceException)
                {
                    return false;
                }
                catch (NoSuchElementException)
                {
                    return true;
                }
            });
        }

        //public bool LinkUndisplayed()
        //{
        //    IWebElement ButtonBlockVanished = driver.FindElement(By.Id("1"));
        //    return ButtonBlockVanished.Displayed;
        //}

        public bool LinkDisplayed()
        {
            return ButtonBlock.Displayed;
        }
        public void ClickLink()
        {
            ButtonBlock.Click();
        }

        public MaliciousPatientsPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public int PatientsCount()
        {
            //return Rows.Count;
            return 0;
        }

        //public string GetLastRowName()
        //{
        //    return LastRowName.Text;
        //}

        //public string GetLastRowColor()
        //{
        //    return LastRowColor.Text;
        //}

        //public string GetLastRowPrice()
        //{
        //    return LastRowPrice.Text;
        //}

        public void Navigate() => driver.Navigate().GoToUrl(URI);
    }
}
