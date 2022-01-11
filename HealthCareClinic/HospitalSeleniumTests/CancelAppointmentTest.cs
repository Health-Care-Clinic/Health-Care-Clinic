using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace HospitalSeleniumTests
{
    public class CancelAppointmentTest : IDisposable
    {
        private readonly IWebDriver driver;
        private Pages.LoginPage loginPage;
        private Pages.HomePagePatientApp homePage;
        //private Pages.MaliciousPatientsPage patientsPage;
        private int patientsCount = 0;
        public CancelAppointmentTest()
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
        public void TestCancelAppointment()
        {
            Assert.True(loginPage.UsernameElementDisplayed());
            Assert.True(loginPage.PasswordElementDisplayed());
            Assert.True(loginPage.SubmitButtonElementDisplayed());
            loginPage.InsertUsername("miki");
            loginPage.InsertPassword("miki");
            loginPage.SubmitForm();

            loginPage.WaitForFormSubmit();
            homePage = new Pages.HomePagePatientApp(driver);
            homePage.EnsureAppointmentsTabelLabelIsDisplayed();     
            Assert.True(homePage.AppointmentsTableLabelElementDisplayed()); 
            homePage.ClickOnAppointments();


            homePage.WaitForListingAppointments();
            homePage.EnsureCancelButtonIsDisplayed();
            Assert.True(homePage.LinkDisplayed());
            patientsCount = homePage.PatientsCount();

            homePage.ClickLink();

            homePage.EnsureCancelButtonIsNotDisplayed();
            Assert.Equal(patientsCount, homePage.PatientsCount());
            Assert.Equal(driver.Url, Pages.HomePagePatientApp.URI);
            Assert.False(homePage.LinkDisplayed());
        }
    }
}
