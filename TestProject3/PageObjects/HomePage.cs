using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using SeleniumExtras.PageObjects;

namespace TestProject3.PageObjects
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
            searchField.SendKeys(searchedProduct + Keys.Enter);
        }

        public void OpenHomePage(string url)
        {
            driver.Navigate().GoToUrl(url);
        }

    }   
}
