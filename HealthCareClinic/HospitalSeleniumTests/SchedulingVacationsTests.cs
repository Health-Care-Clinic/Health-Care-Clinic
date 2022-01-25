using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xunit;

namespace HospitalSeleniumTests
{
    public class SchedulingVacationsTests
    {
        private readonly IWebDriver driver;
        private Pages.LoginPageForManager loginPage;
        private Pages.HomePageManagerApp homePage;
        private Pages.AllDoctorsPage doctorsPage;
        private Pages.DoctorVacationsPage vacationsPage;
        private Pages.AddNewVacationPage addNewVacationPage;

        public SchedulingVacationsTests()
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
        public void ScheduleVacationToDoctor()
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
            doctorsPage.ClickOnVacations();

            vacationsPage = new Pages.DoctorVacationsPage(driver);

            vacationsPage.WaitForListingPastVacations();
            vacationsPage.EnsurePastVacationsTabelLabelIsDisplayed();
            vacationsPage.WaitForListingCurrentVacations();
            vacationsPage.EnsureCurrentVacationsTabelLabelIsDisplayed();
            vacationsPage.WaitForListingFutureVacations();
            vacationsPage.EnsureFutureVacationsTabelLabelIsDisplayed();
            ReadOnlyCollection<IWebElement> futureRowsBefore = vacationsPage.RowsOfFutureVacations;
            Assert.True(vacationsPage.ScheduleVacationsButtonDisplayed());
            Assert.Equal(driver.Url, Pages.DoctorVacationsPage.URI);
            vacationsPage.ClickOnScheduleVacation();

            addNewVacationPage = new Pages.AddNewVacationPage(driver);
            Assert.True(addNewVacationPage.StartDateDisplayed());
            Assert.Equal(driver.Url, Pages.AddNewVacationPage.URI);
            addNewVacationPage.InsertStartDate("11-02-2022");

            Assert.True(addNewVacationPage.EndDateDisplayed());
            addNewVacationPage.InsertEndDate("12-02-2022");

            Assert.True(addNewVacationPage.DescriptionDisplayed());
            addNewVacationPage.InsertDescription("Neki opis");

            Assert.True(addNewVacationPage.FinishButtonDisplayed());
            addNewVacationPage.ClickOnFinishButton();

            vacationsPage = new Pages.DoctorVacationsPage(driver);

            Assert.Equal(driver.Url, Pages.DoctorVacationsPage.URI);
            vacationsPage.WaitForListingPastVacations();
            vacationsPage.EnsurePastVacationsTabelLabelIsDisplayed();
            vacationsPage.WaitForListingCurrentVacations();
            vacationsPage.EnsureCurrentVacationsTabelLabelIsDisplayed();
            vacationsPage.WaitForListingFutureVacations();
            vacationsPage.EnsureFutureVacationsTabelLabelIsDisplayed();
            

            Assert.Equal(futureRowsBefore.Count + 1, vacationsPage.RowsOfFutureVacations.Count);
        }
    }
}
