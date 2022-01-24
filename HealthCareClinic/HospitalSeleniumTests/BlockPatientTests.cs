using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using NUnit.Framework;

namespace HospitalSeleniumTests
{
    public class BlockPatientTests : IDisposable
    {
        private IWebDriver driver = null;
        private Pages.LoginPage loginPage;
        private Pages.HomePage homePage;
        private Pages.MaliciousPatientsPage patientsPage;
        private int patientsCount = 0;

        [OneTimeSetUp]
        public void Setup()
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

#if RELEASE
            options.AddArguments('--headless');
#endif

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


        [Test]
        public void TestBlockPatient()
        {
            Assert.True(loginPage.UsernameElementDisplayed());
            Assert.True(loginPage.PasswordElementDisplayed());
            Assert.True(loginPage.SubmitButtonElementDisplayed());
            loginPage.InsertUsername("admin");
            loginPage.InsertPassword("admin");
            loginPage.SubmitForm();

            loginPage.WaitForFormSubmit();
            homePage = new Pages.HomePage(driver);
            homePage.EnsureButtonIsDisplayed();
            Assert.True(homePage.BlockPatientsButtonElementDisplayed());
            homePage.ClickOnBlocking();


            homePage.WaitForListingMalicious();
            patientsPage = new Pages.MaliciousPatientsPage(driver);
            patientsPage.EnsureButtonIsDisplayed();
            Assert.True(patientsPage.LinkDisplayed());
            Assert.AreEqual(driver.Url, Pages.MaliciousPatientsPage.URI);
            patientsCount = patientsPage.PatientsCount();

            patientsPage.ClickLink();

            patientsPage.EnsureButtonIsNotDisplayed();
            Assert.AreEqual(patientsCount - 1, patientsPage.PatientsCount());
            Assert.AreEqual(driver.Url, Pages.MaliciousPatientsPage.URI);
            Assert.False(patientsPage.LinkDisplayed());
        }

    }
}
