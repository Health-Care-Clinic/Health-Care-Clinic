using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xunit;

namespace HospitalSeleniumTests
{
    public class AddOnCallShiftToDoctorTests : IDisposable
    {
        private readonly IWebDriver driver;
        private Pages.LoginPageForManager loginPage;
        private Pages.HomePageManagerApp homePage;
        private Pages.AllDoctorsPage doctorsPage;
        private Pages.OnCallShiftsPage onCallShiftsPage;
        private Pages.AddNewOnCallShiftPage addNewOnCallShiftPage;

        public AddOnCallShiftToDoctorTests()
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
        public void AddOnCallShiftToDoctor()
        {
            Assert.True(loginPage.UsernameElementDisplayed());
            Assert.True(loginPage.PasswordElementDisplayed());
            Assert.True(loginPage.SubmitButtonElementDisplayed());
            loginPage.InsertUsername("admin");
            loginPage.InsertPassword("admin");
            loginPage.SubmitForm();

            loginPage.WaitForFormSubmit();
            homePage = new Pages.HomePageManagerApp(driver);

            Assert.True(homePage.FacilityButtonDisplayed());
            homePage.ClickOnFacility();

            Assert.True(homePage.DoctorsButtonDisplayed());
            homePage.ClickOnDoctors();

            doctorsPage = new Pages.AllDoctorsPage(driver);

            doctorsPage.WaitForListingDoctors();
            doctorsPage.EnsureDoctorsTabelLabelIsDisplayed();
            Assert.True(doctorsPage.OnCallShiftButtonDisplayed());
            Assert.Equal(driver.Url, Pages.AllDoctorsPage.URI);
            doctorsPage.ClickOnOnCallShifts();

            onCallShiftsPage = new Pages.OnCallShiftsPage(driver);

            onCallShiftsPage.WaitForListingShifts();
            onCallShiftsPage.EnsureShiftsTabelLabelIsDisplayed();
            ReadOnlyCollection<IWebElement> rowsBefore = onCallShiftsPage.RowsOfShifts;
            Assert.True(onCallShiftsPage.AddNewOnCallShiftButtonDisplayed());
            Assert.Equal(driver.Url, Pages.OnCallShiftsPage.URI);
            onCallShiftsPage.ClickOnAddNewOnCallShift();

            addNewOnCallShiftPage = new Pages.AddNewOnCallShiftPage(driver);

            Assert.True(addNewOnCallShiftPage.NextButtonDisplayed());
            Assert.Equal(driver.Url, Pages.AddNewOnCallShiftPage.URI);
            addNewOnCallShiftPage.ClickOnNextButton();

            addNewOnCallShiftPage.WaitForListingFreeTerms();
            addNewOnCallShiftPage.EnsureFreeTermsTabelLabelIsDisplayed();
            Assert.True(addNewOnCallShiftPage.InputElementDisplayed());
            addNewOnCallShiftPage.ClickOnRadioInput();

            Assert.True(addNewOnCallShiftPage.AddShiftButtonDisplayed());
            addNewOnCallShiftPage.ClickOnAddButton();

            doctorsPage = new Pages.AllDoctorsPage(driver);

            doctorsPage.WaitForListingDoctors();
            doctorsPage.EnsureDoctorsTabelLabelIsDisplayed();
            Assert.True(doctorsPage.OnCallShiftButtonDisplayed());
            Assert.Equal(driver.Url, Pages.AllDoctorsPage.URI);
            doctorsPage.ClickOnOnCallShifts();

            onCallShiftsPage = new Pages.OnCallShiftsPage(driver);

            onCallShiftsPage.WaitForListingShifts();
            onCallShiftsPage.EnsureShiftsTabelLabelIsDisplayed();
            Assert.Equal(driver.Url, Pages.OnCallShiftsPage.URI);

            Assert.Equal(rowsBefore.Count + 1, onCallShiftsPage.RowsOfShifts.Count);
        }
    }
}
