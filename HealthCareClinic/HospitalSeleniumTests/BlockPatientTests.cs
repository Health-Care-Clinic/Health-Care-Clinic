using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using System;
using Xunit;
using System.IO;

namespace HospitalSeleniumTests
{
    public class BlockPatientTests : IDisposable
    {
        private readonly IWebDriver driver;
        private Pages.LoginPage loginPage;
        private Pages.HomePage homePage;
        private Pages.MaliciousPatientsPage patientsPage;
        private int patientsCount = 0;


        public BlockPatientTests()
        {
            string workingDirectory = Environment.CurrentDirectory;
            System.Environment.SetEnvironmentVariable("webdriver.chrome.driver", @workingDirectory + Path.PathSeparator + "netcoreapp3.1" + Path.PathSeparator + "chromedriver.exe");
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
            Assert.Equal(driver.Url, Pages.MaliciousPatientsPage.URI);
            patientsCount = patientsPage.PatientsCount();

            patientsPage.ClickLink();

            patientsPage.EnsureButtonIsNotDisplayed();
            Assert.Equal(patientsCount - 1, patientsPage.PatientsCount());
            Assert.Equal(driver.Url, Pages.MaliciousPatientsPage.URI);
            Assert.False(patientsPage.LinkDisplayed());
        }

    }
}
