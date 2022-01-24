using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace HospitalSeleniumTests.Pages
{
    public class UrgentProcurementPage
    {
        private readonly IWebDriver _driver;
        public const string URI = "http://localhost:4200/urgent-procurement";
        private ReadOnlyCollection<IWebElement> Rows => _driver.FindElements(By.XPath("//table[@id='pharmacyTable']/tr"));
        private IWebElement MedicineName => _driver.FindElement(By.Id("medicineName"));
        private IWebElement MedicineAmount => _driver.FindElement(By.Id("medicineAmount"));
        private IWebElement OrderDialogButton => _driver.FindElement(By.Id("orderDialogButton"));
        private IWebElement OrderMedicineButton => _driver.FindElement(By.XPath("//table[@id='pharmacyTable']/tr[2]/td[4]/button"));
        private IWebElement CheckMedicineButton => _driver.FindElement(By.XPath("//table[@id='pharmacyTable']/tr[3]/td[4]/button"));
        public string Title => _driver.Title;
        public const string InvalidMedicineNameMessage = "Molimo unesite naziv leka.";
        public const string InvalidMedicineAmountMessage = "Molimo unesite kolicinu leka.";
        public const string MedicineAmountIsNaNMessage = "Molimo unesite validan broj za kolicinu leka.";

        public UrgentProcurementPage(IWebDriver driver)
        {
            _driver = driver;
        }

        public void EnsurePageIsDisplayed()
        {
            var wait = new WebDriverWait(_driver, new TimeSpan(0, 0, 20));
            wait.Until(condition =>
            {
                try
                {
                    return Rows.Count > 1;
                }
                catch (StaleElementReferenceException)
                {
                    return false;
                }
                catch (NoSuchElementException)
                {
                    return false;
                }
            });
        }

        public void CheckMedicine()
        {
            CheckMedicineButton.Click();
        }
        public void Order()
        {
            var wait = new WebDriverWait(_driver, new TimeSpan(0, 0, 10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.Id("orderDialogButton")));
            OrderDialogButton.Click();
        }


        public bool MedicineNameDisplayed()
        {
            return MedicineName.Displayed;
        }

        public bool MedicineAmountDisplayed()
        {
            return MedicineAmount.Displayed;
        }

        public bool OrderMedicineButtonDisplayed()
        {
            return OrderMedicineButton.Displayed;
        }

        public void InsertMedicineName(string name)
        {
            MedicineName.SendKeys(name);
        }

        public void InsertMedicineAmount(string amount)
        {
            MedicineAmount.SendKeys(amount);
        }

        public void OrderMedicine()
        {
            OrderMedicineButton.Click();
        }

        public void WaitForAlertDialog()
        {
            var wait = new WebDriverWait(_driver, new TimeSpan(0, 0, 10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.AlertIsPresent());
        }

        public string GetDialogMessage()
        {
            return _driver.SwitchTo().Alert().Text;
        }

        public void ResolveAlertDialog()
        {
            _driver.SwitchTo().Alert().Accept();
        }

        public void Wait()
        {
            var wait = new WebDriverWait(_driver, new TimeSpan(0, 0, 20));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.UrlToBe(HomePage.URI));
        }

        public void Navigate() => _driver.Navigate().GoToUrl(URI);

        public static string MedicineNotFoundMessage(string medicineName)
        {
            return "Lek " + medicineName + " ne postoji u navedenoj apoteci.";
        }

        public static string MedicineAmountIsLessThenRequestedMessage(string medicineName, int medicineAmount)
        {
            return "Lek " + medicineName + " ne postoji u navedenoj kolicini (" + medicineAmount + ").";
        }

        public static string MedicineTransferedMessage(string medicineName, int medicineAmount)
        {
            return "Lek " + medicineName + " je prebacen u vasu bolnicu (kolicina: " + medicineAmount + ").";
        }

        public static string OrderError()
        {
            return "Does not exist.";
        }

        public static string SuccessMessage()
        {
            return "Medicine moved!";
        }
    }
}

