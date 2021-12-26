using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;
using SeleniumExtras.WaitHelpers;
namespace TestProject3.PageObjects
{

    public class BasePage
    {
        protected IWebDriver driver;

        public BasePage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        public void WaitToPageLoadComplete(int timeout)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout));

            // Wait for the page to load
            wait.Until(d => ((IJavaScriptExecutor)d).
                            ExecuteScript("return document.readyState").Equals("complete"));
        }

        public void WaitAjaxLoadComplete(int timeout)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout));

            // Wait for ajax to load
            wait.Until(d => ((IJavaScriptExecutor)d).
                            ExecuteScript("return window.jQuery != undefined && jQuery.active == 0;"));
        }

        public void WaitVisibilityOfElement(int timeout, IWebElement element)
        {
            // wait element clickability
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout));
            wait.Until(ExpectedConditions.ElementToBeClickable(element));
        }

    }
}
