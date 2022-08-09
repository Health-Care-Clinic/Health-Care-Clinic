using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalSeleniumTests.Pages
{
    public class CreateFeedbackPage
    {
        private readonly IWebDriver driver;
        public const string URI = "http://localhost:4200/";
        private IWebElement FeedbackTextAreaElement => driver.FindElement(By.Id("feedbackTextArea"));
        private IWebElement SubmitFeedbackButtonElement => driver.FindElement(By.Id("feedbackSubmit"));
        public string Title => driver.Title;

        public CreateFeedbackPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        internal void PopulateFeedbackTextArea(string comment)
        {
            FeedbackTextAreaElement.SendKeys(comment);
        }

        internal bool FeedbackTextAreaValid()
        {
            return FeedbackTextAreaElement.Text.Equals(String.Empty);
        }

        internal bool SubmitButtonEnabled()
        {
            return SubmitFeedbackButtonElement.Enabled;
        }

        internal void ClickOnSubmitButton()
        {
            SubmitFeedbackButtonElement.Click();
        }

        internal void WaitForHomePage()
        {
            var wait = new WebDriverWait(driver, new TimeSpan(0, 0, 10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.UrlToBe("http://localhost:4200/"));        
        }
    }
}
