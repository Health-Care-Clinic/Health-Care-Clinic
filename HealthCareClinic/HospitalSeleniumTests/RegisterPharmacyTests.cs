using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Xunit;

namespace HospitalSeleniumTests
{
    public class RegisterPharmacyTests : IDisposable
    {

        private readonly IWebDriver _driver;
        private Pages.RegisterPharmacyPage registerPharmacyPage;


        public RegisterPharmacyTests()
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

            registerPharmacyPage = new Pages.RegisterPharmacyPage(_driver);
            registerPharmacyPage.Navigate();
            registerPharmacyPage.EnsureButtonIsDisplayed();

            Assert.Equal(_driver.Url, Pages.RegisterPharmacyPage.URI);


            Assert.True(registerPharmacyPage.PharmacyNameElementDisplayed());
            Assert.True(registerPharmacyPage.UrlElementDisplayed());
            Assert.True(registerPharmacyPage.RegisterButtonElementDisplayed());
        }

        

        [Fact]
        public void MissingPharmacyName()
        {
            registerPharmacyPage.InsertPharmacyName("");
            registerPharmacyPage.InsertUrl("http://localhost:3100");
            registerPharmacyPage.RegisterPharmacy();

            registerPharmacyPage.WaitForAlertDialog();
            Assert.Equal(registerPharmacyPage.GetDialogMessage(), Pages.RegisterPharmacyPage.MissingInputMessage);
            registerPharmacyPage.ResolveAlertDialog();
            Assert.Equal(_driver.Url, Pages.RegisterPharmacyPage.URI);
        }


        [Fact]
        public void MissingPharmacyUrl()
        {
            registerPharmacyPage.InsertPharmacyName("pharmacy");
            registerPharmacyPage.InsertUrl("");
            registerPharmacyPage.RegisterPharmacy();

            registerPharmacyPage.WaitForAlertDialog();
            Assert.Equal(registerPharmacyPage.GetDialogMessage(), Pages.RegisterPharmacyPage.MissingInputMessage);
            registerPharmacyPage.ResolveAlertDialog();
            Assert.Equal(_driver.Url, Pages.RegisterPharmacyPage.URI);
        }

        [Fact]
        public void InvalidPharmacyUrl()
        {
            registerPharmacyPage.InsertPharmacyName("pharmacy");
            registerPharmacyPage.InsertUrl("k");
            registerPharmacyPage.RegisterPharmacy();

            registerPharmacyPage.WaitForAlertDialog();
            Assert.Equal(registerPharmacyPage.GetDialogMessage(), Pages.RegisterPharmacyPage.InvalidUrlMessage);
            registerPharmacyPage.ResolveAlertDialog();
            Assert.Equal(_driver.Url, Pages.RegisterPharmacyPage.URI);
        }

        [Fact]
        public void SuccessfulRegistration()
        {
            registerPharmacyPage.InsertPharmacyName("pharmacy");
            registerPharmacyPage.InsertUrl("http://localhost:3100");
            registerPharmacyPage.RegisterPharmacy();

            registerPharmacyPage.WaitForAlertDialog();
            Assert.Equal(registerPharmacyPage.GetDialogMessage(), Pages.RegisterPharmacyPage.SuccessMessage);
            registerPharmacyPage.ResolveAlertDialog();
            Assert.Equal(_driver.Url, Pages.RegisterPharmacyPage.URI);
        }



        public void Dispose()
        {
            _driver.Quit();
            _driver.Dispose();
        }
    }
}
