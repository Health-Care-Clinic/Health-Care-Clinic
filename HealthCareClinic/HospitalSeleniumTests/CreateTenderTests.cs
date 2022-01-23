using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Xunit;

namespace HospitalSeleniumTests
{
    public class CreateTenderTests : IDisposable
    {
        private readonly IWebDriver _driver;
        private Pages.CreateTenderPage createTenderPage;
        private Pages.LoginPage loginPage;

        public CreateTenderTests()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArguments("start-maximized");            
            options.AddArguments("disable-infobars");           
            options.AddArguments("--disable-extensions");       
            options.AddArguments("--disable-gpu");              
            options.AddArguments("--disable-dev-shm-usage");    
            options.AddArguments("--no-sandbox");               
            options.AddArguments("--disable-notifications");

            _driver = new ChromeDriver(options);

            createTenderPage = new Pages.CreateTenderPage(_driver);
            createTenderPage.Navigate();
            createTenderPage.EnsureButtonIsDisplayed();

            Assert.Equal(_driver.Url, Pages.CreateTenderPage.URI);

            Assert.True(createTenderPage.StartDateElementDisplayed());
            Assert.True(createTenderPage.EndDateElementDisplayed());
            Assert.True(createTenderPage.DescriptionElementDisplayed());
            Assert.True(createTenderPage.MedicineNameElementDisplayed());
            Assert.True(createTenderPage.QuantityElementDisplayed());
            Assert.True(createTenderPage.SubmitButtonElementDisplayed());
        }

        [Fact]
        public void SuccessfulSubmit()
        {
            createTenderPage.InsertStartDate("01/01/2022");
            createTenderPage.InsertEndDate("02/02/2022");
            createTenderPage.InsertDescription("Tender description");
            createTenderPage.InsertMedicineName("Brufen");
            createTenderPage.InsertQuantity("100");
            createTenderPage.CreateTender();

        }

        public void Dispose()
        {
            _driver.Quit();
            _driver.Dispose();
        }
    }
}
