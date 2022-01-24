using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace HospitalSeleniumTests
{
    public class CreateFeedbackTests : IDisposable
    {
        private readonly IWebDriver driver;
        private Pages.LoginPage loginPage;
        private Pages.HomePagePatientApp homePage;
        private Pages.CreateFeedbackPage createFeedbackPage;

        public CreateFeedbackTests()
        {
            // options for launching Google Chrome
            ChromeOptions options = new ChromeOptions();
            options.AddArguments("start-maximized");            // open Browser in maximized mode
            options.AddArguments("disable-infobars");           // disabling infobars
            options.AddArguments("--disable-extensions");       // disabling extensions
            options.AddArguments("--disable-gpu");              // applicable to windows os only
            options.AddArguments("--disable-dev-shm-usage");    // overcome limited resource problems
            options.AddArguments("--no-sandbox");               // Bypass OS security model
            options.AddArguments("--disable-notifications");    // disable notifications

            driver = new ChromeDriver(options);

            loginPage = new Pages.LoginPage(driver);
            loginPage.Navigate();
            loginPage.EnsureButtonIsDisplayed();
        }

        public void Dispose()
        {
            driver.Quit();
            driver.Dispose();
        }

        [Fact]
        public void TestCreateFeedback()
        {
            Assert.True(loginPage.UsernameElementDisplayed());
            Assert.True(loginPage.PasswordElementDisplayed());
            Assert.True(loginPage.SubmitButtonElementDisplayed());
            loginPage.InsertUsername("zorka");
            loginPage.InsertPassword("zorka");
            loginPage.SubmitForm();

            loginPage.WaitForFormSubmit();
            homePage = new Pages.HomePagePatientApp(driver);
            homePage.EnsureAppointmentsTabelLabelIsDisplayed();
            Assert.True(homePage.AppointmentsTableLabelElementDisplayed());
            homePage.ClickOnCreateFeedback();


            homePage.WaitForFeedbackFormPage();
            createFeedbackPage = new Pages.CreateFeedbackPage(driver);
            createFeedbackPage.PopulateFeedbackTextArea("Neki komentar.");
            Assert.True(createFeedbackPage.FeedbackTextAreaValid());
            Assert.True(createFeedbackPage.SubmitButtonEnabled());

            createFeedbackPage.ClickOnSubmitButton();
            createFeedbackPage.WaitForHomePage();
            Assert.Equal("http://localhost:4200/", driver.Url);
        }
    }
}
