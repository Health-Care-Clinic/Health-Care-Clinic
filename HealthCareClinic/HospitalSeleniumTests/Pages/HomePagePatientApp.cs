using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.ObjectModel;

namespace HospitalSeleniumTests.Pages
{
    public class HomePagePatientApp
    {
        private readonly IWebDriver driver;
        public const string URI = "http://localhost:4200/medical-record";
        private IWebElement AppointmentsTabelLabelElement => driver.FindElement(By.Id("mat-tab-label-0-3"));
        public string Title => driver.Title;


        public void EnsureAppointmentsTabelLabelIsDisplayed()
        {
            var wait = new WebDriverWait(driver, new TimeSpan(0, 0, 10));
            wait.Until(condition =>
            {
                try
                {
                    return AppointmentsTableLabelElementDisplayed();
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

        public bool AppointmentsTableLabelElementDisplayed()
        {
            return AppointmentsTabelLabelElement.Displayed;
        }

        public void ClickOnAppointments()
        {
            AppointmentsTabelLabelElement.Click();
        }

        public HomePagePatientApp(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void WaitForListingAppointments()
        {
            var wait = new WebDriverWait(driver, new TimeSpan(0, 0, 5));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//*[@id='Appointments']"))); // cela tabela appointmenta
        }

        public void Navigate() => driver.Navigate().GoToUrl(URI);

        private ReadOnlyCollection<IWebElement> Rows => driver.FindElements(By.XPath("//table[@id='Appointments']/tbody/mat-row"));
        private IWebElement ButtonCancel => driver.FindElement(By.Id("7"));

        public void EnsureCancelButtonIsDisplayed()
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

        public void EnsureCancelButtonIsNotDisplayed()
        {
            var wait = new WebDriverWait(driver, new TimeSpan(0, 0, 5));
            wait.Until(condition =>
            {
                try
                {
                    IWebElement ButtonCancel = driver.FindElement(By.Id("7"));
                    return ButtonCancel.Displayed;
                }
                catch (StaleElementReferenceException)
                {
                    return false;
                }
                catch (NoSuchElementException)
                {
                    return true;
                }
                catch (UnhandledAlertException)
                {
                    return true;
                }
            });
        }

        public bool LinkDisplayed()
        {
            try
            {
                IWebElement ButtonCancel = driver.FindElement(By.Id("7"));
                return ButtonCancel.Displayed;
            }
            catch
            {
                return false;
            }
        }
        public void ClickLink()
        {
            ButtonCancel.Click();
            var wait = new WebDriverWait(driver, new TimeSpan(0, 0, 5));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//*[@id='Appointments']"))); // cela tabela appointmenta
        }


        public int PatientsCount()
        {
            return Rows.Count;
            //return 0;
        }
    }
}
