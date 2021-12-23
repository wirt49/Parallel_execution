using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using SeleniumExtras.PageObjects;

namespace HomeTask_Epam_2.PageObjects
{
    public class HomePage : BasePage
    {
        
        [FindsBy(How = How.XPath, Using = "//input[@name ='search']")]
        private IWebElement searchField;

        private readonly WebDriverWait wait;

        public HomePage(IWebDriver driver) : base(driver)
        {
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));

        }

        public void Search(string searchedProduct)
        {
            //driver.FindElement(By.XPath(searchFieldXpath)).
            //    SendKeys(searchedProduct + Keys.Enter);
            searchField.SendKeys(searchedProduct + Keys.Enter);
        }

    }   
}
