using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace HospitalSeleniumTests
{ 
    public class SearchRoomsTests : IDisposable
    {
        private readonly IWebDriver driver;
        private Pages.LoginPageForManager loginPage;
        private Pages.HomePageManagerApp homePage;
        private Pages.DisplaySearchedRoomsPage searchedRoomsPage;
        

        public SearchRoomsTests()
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

            loginPage = new Pages.LoginPageForManager(driver);
            loginPage.Navigate();
            loginPage.EnsureButtonIsDisplayed();
        }

        public void Dispose()
        {
            driver.Quit();
            driver.Dispose();
        }

        [Fact]
        public void SearchRoomsByName() {
            Assert.True(loginPage.UsernameElementDisplayed());
            Assert.True(loginPage.PasswordElementDisplayed());
            Assert.True(loginPage.SubmitButtonElementDisplayed());
            loginPage.InsertUsername("admin");
            loginPage.InsertPassword("admin");
            loginPage.SubmitForm();

            loginPage.WaitForFormSubmit();
            homePage = new Pages.HomePageManagerApp(driver);

            Assert.True(homePage.SearchRoomsElementDisplayed());
            homePage.InsertRoomName("Ope");

            Assert.True(homePage.SearchButtonDisplayed());
            homePage.ClickOnSearch();

            searchedRoomsPage = new Pages.DisplaySearchedRoomsPage(driver);

            searchedRoomsPage.WaitForListingRooms();
            searchedRoomsPage.EnsureRoomsTabelLabelIsDisplayed();
            Assert.Equal(driver.Url, Pages.DisplaySearchedRoomsPage.URI);
            searchedRoomsPage.ClickOnSearchedRoom();

            Assert.Equal(driver.Url, "http://localhost:4200/floor/1/1/1");
        }
    }
}
