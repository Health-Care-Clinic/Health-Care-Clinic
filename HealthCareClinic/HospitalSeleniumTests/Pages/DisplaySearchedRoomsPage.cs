using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace HospitalSeleniumTests.Pages
{
    public class DisplaySearchedRoomsPage
    {
        private readonly IWebDriver driver;
        public const string URI = "http://localhost:4200/room-search-result/Ope";
        public ReadOnlyCollection<IWebElement> RowsOfSearchedRooms => driver.FindElements(By.XPath("//table[@id='searchedRooms']/tbody/tr"));
        private IWebElement SearchedRoomButton => driver.FindElement(By.Id("0"));

        public DisplaySearchedRoomsPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void EnsureRoomsTabelLabelIsDisplayed()
        {
            var wait = new WebDriverWait(driver, new TimeSpan(0, 0, 70));
            wait.Until(condition =>
            {
                try
                {
                    return RowsOfSearchedRooms.Count > 0;
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

        public void ClickOnSearchedRoom()
        {
            SearchedRoomButton.Click();
        }

        public void WaitForListingRooms()
        {
            var wait = new WebDriverWait(driver, new TimeSpan(0, 0, 70));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//*[@id='searchedRooms']")));
        }
    }
}
