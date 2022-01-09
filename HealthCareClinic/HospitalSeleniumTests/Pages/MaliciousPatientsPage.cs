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
        private ReadOnlyCollection<IWebElement> Rows => driver.FindElements(By.XPath("//table[@id='maliciousPatients']/tbody/mat-row"));
        private IWebElement ButtonBlock => driver.FindElement(By.Id("1"));
        public string Title => driver.Title;
        public void EnsureButtonIsDisplayed()
        {
            var wait = new WebDriverWait(driver, new TimeSpan(0, 0, 30));
            wait.Until(condition =>
            {
                try
                {
                    return LinkDisplayed() && Rows.Count > 0;
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
                    IWebElement ButtonBlock = driver.FindElement(By.Id("1"));
                    return ButtonBlock.Displayed;
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

        public bool LinkDisplayed()
        {
            try 
            {
                IWebElement ButtonBlock = driver.FindElement(By.Id("1"));
                return ButtonBlock.Displayed;
            }
            catch
            {
                return false;
            }                     
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
            return Rows.Count;
            //return 0;
        }

        public void Navigate() => driver.Navigate().GoToUrl(URI);
    }
}
