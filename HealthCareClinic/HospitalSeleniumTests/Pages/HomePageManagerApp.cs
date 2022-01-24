using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace HospitalSeleniumTests.Pages
{
    public class HomePageManagerApp
    {
        private readonly IWebDriver driver;
        public const string URI = "http://localhost:4200/hospital-map";
        private IWebElement OurFacilityButton => driver.FindElement(By.Id("facility"));
        private IWebElement DoctorsButton => driver.FindElement(By.Id("doctors"));

        public HomePageManagerApp(IWebDriver driver) 
        {
            this.driver = driver;
        }

        public bool FacilityButtonDisplayed() {
            return OurFacilityButton.Displayed;
        }

        public bool DoctorsButtonDisplayed()
        {
            return DoctorsButton.Displayed;
        }

        public void ClickOnFacility()
        {
            OurFacilityButton.Click();
        }

        public void ClickOnDoctors()
        {
            DoctorsButton.Click();
        }

        public void Navigate() => driver.Navigate().GoToUrl(URI);
    }
}
