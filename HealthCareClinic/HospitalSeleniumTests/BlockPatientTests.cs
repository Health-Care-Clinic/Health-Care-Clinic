using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using Xunit;

namespace HospitalSeleniumTests
{
    public class BlockPatientTests : IDisposable
    {
        private readonly IWebDriver driver;
        private Pages.MaliciousPatientsPage patientsPage;
        private int patientsCount = 0;


        public BlockPatientTests()
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


            patientsPage = new Pages.MaliciousPatientsPage(driver);      // create ProductsPage
            patientsPage.Navigate();                            // navigate to url
            patientsPage.EnsureButtonIsDisplayed();               // wait for table to populate        
        }
        public void Dispose()
        {
            driver.Quit();
            driver.Dispose();
        }


        [Fact]
        public void TestBlockPatient()
        {
            Assert.True(patientsPage.LinkDisplayed());          // check if link displayed
            Assert.Equal(driver.Url, Pages.MaliciousPatientsPage.URI);
            patientsCount = patientsPage.PatientsCount();       // get number of table rows - after create successful sheck if number increased

            patientsPage.ClickLink();                           // click link and navigate to CreateProductPage

            patientsPage.EnsureButtonIsNotDisplayed();
            Assert.False(patientsPage.LinkDisplayed());

            //Assert.Equal(patientsCount - 1, patientsPage.PatientsCount());           // check if number of rows increased  
        }

    }
}
