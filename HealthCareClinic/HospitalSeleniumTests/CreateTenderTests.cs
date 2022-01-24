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
            Assert.True(createTenderPage.AddMedicineButtonDisplayed());
        }

        [Fact]
        public void SuccessfulSubmit()
        {
            createTenderPage.InsertStartDate("01/01/2022");
            createTenderPage.InsertEndDate("02/02/2022");
            createTenderPage.InsertDescription("Tender description");
            createTenderPage.InsertMedicineName("Brufen");
            createTenderPage.InsertQuantity("100");
            createTenderPage.AddMedicine();
            createTenderPage.CreateTender();

            createTenderPage.WaitForAlertDialog();
            Assert.Equal(createTenderPage.GetDialogMessage(), Pages.CreateTenderPage.SuccessMessage);
            createTenderPage.ResolveAlertDialog();
            Assert.Equal(_driver.Url, Pages.CreateTenderPage.URI);
        }

        [Fact]
        public void MissingDescriptionSubmit()
        {
            createTenderPage.InsertStartDate("01/01/2022");
            createTenderPage.InsertEndDate("02/02/2022");
            createTenderPage.InsertDescription("");
            createTenderPage.InsertMedicineName("Brufen");
            createTenderPage.InsertQuantity("100");
            createTenderPage.AddMedicine();
            createTenderPage.CreateTender();

            createTenderPage.WaitForAlertDialog();
            Assert.Equal(createTenderPage.GetDialogMessage(), Pages.CreateTenderPage.MissingDescriptionMessage);
            createTenderPage.ResolveAlertDialog();
            Assert.Equal(_driver.Url, Pages.CreateTenderPage.URI);
        }

        [Fact]
        public void MissingMedicineNameSubmit()
        {
            createTenderPage.InsertStartDate("01/01/2022");
            createTenderPage.InsertEndDate("02/02/2022");
            createTenderPage.InsertDescription("Tender description");
            createTenderPage.InsertMedicineName("");
            createTenderPage.InsertQuantity("100");
            createTenderPage.AddMedicine();

            createTenderPage.WaitForAlertDialog();
            Assert.Equal(createTenderPage.GetDialogMessage(), Pages.CreateTenderPage.MissingMedicineNameMessage);
            createTenderPage.ResolveAlertDialog();
            Assert.Equal(_driver.Url, Pages.CreateTenderPage.URI);

            createTenderPage.CreateTender();
        }

        [Fact]
        public void MissingMedicineQuantitySubmit()
        {
            createTenderPage.InsertStartDate("01/01/2022");
            createTenderPage.InsertEndDate("02/02/2022");
            createTenderPage.InsertDescription("Tender description");
            createTenderPage.InsertMedicineName("Brufen");
            createTenderPage.InsertQuantity("");
            createTenderPage.AddMedicine();

            createTenderPage.WaitForAlertDialog();
            Assert.Equal(createTenderPage.GetDialogMessage(), Pages.CreateTenderPage.MissingMedicineQuantityMessage);
            createTenderPage.ResolveAlertDialog();
            Assert.Equal(_driver.Url, Pages.CreateTenderPage.URI);

            createTenderPage.CreateTender();
        }

        public void Dispose()
        {
            _driver.Quit();
            _driver.Dispose();
        }
    }
}
