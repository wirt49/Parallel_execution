using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading.Tasks;
using SeleniumExtras.PageObjects;

namespace HomeTask_Epam_2.PageObjects
{
    public class SearchResultPage : BasePage
    {
        Int32 timeout = 100000;

        [FindsBy(How = How.XPath, Using = "//option[contains(@value, 'expensive')]")]
        private IWebElement expensiveSort;

        [FindsBy(How = How.XPath, Using = "//app-buy-button[@class = 'toOrder ng-star-inserted']")]
        private IWebElement addToCartButton;
        private IWebElement elemFirstResult;


        public SearchResultPage(IWebDriver driver) : base(driver) { }

        async void Async_delay()
        {
            await Task.Delay(50);
        }

        public void ExpensiveSort()
        {
            expensiveSort.Click();
        }

        public void AddToCartMostExpensiveProd()
        {
            addToCartButton.Click();
        }
        public void LoadComplete()
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromMilliseconds(timeout));

            // Wait for the page to load
            wait.Until(d => ((IJavaScriptExecutor)d).ExecuteScript("return document.readyState").Equals("complete"));
        }

        public CartPage СlickSearchResults()
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromMilliseconds(timeout));

            // Wait for the page to load
            wait.Until(d => ((IJavaScriptExecutor)d).ExecuteScript("return document.readyState").Equals("complete"));

            elemFirstResult.Click();

            Async_delay();

            return new CartPage(driver);
        }


    }
}
