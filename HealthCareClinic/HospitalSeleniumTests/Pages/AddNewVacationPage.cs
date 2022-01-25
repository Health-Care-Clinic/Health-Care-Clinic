using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalSeleniumTests.Pages
{
    public class AddNewVacationPage
    {
        private readonly IWebDriver driver;
        public const string URI = "http://localhost:4200/schedule-a-vacation/3";

        private IWebElement StartDatePicker => driver.FindElement(By.Id("startDate"));
        private IWebElement EndDatePicker => driver.FindElement(By.Id("endDate"));
        private IWebElement DescriptionInput => driver.FindElement(By.Id("description"));
        private IWebElement FinishButton => driver.FindElement(By.Id("finish"));

        public AddNewVacationPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void ClickOnFinishButton()
        {
            FinishButton.Click();
        }

        public bool FinishButtonDisplayed()
        {
            return FinishButton.Displayed;
        }

        public bool StartDateDisplayed()
        {
            return StartDatePicker.Displayed;
        }

        public bool EndDateDisplayed()
        {
            return EndDatePicker.Displayed;
        }

        public bool DescriptionDisplayed()
        {
            return DescriptionInput.Displayed;
        }

        public void InsertStartDate(String date)
        {
            StartDatePicker.SendKeys(date);
        }

        public void InsertEndDate(String date)
        {
            EndDatePicker.SendKeys(date);
        }

        public void InsertDescription(String description)
        {
            DescriptionInput.SendKeys(description);
        }
    }
}
