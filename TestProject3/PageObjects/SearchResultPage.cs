using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading.Tasks;
using SeleniumExtras.PageObjects;

namespace TestProject3.PageObjects
{
    public class SearchResultPage : BasePage
    {

        [FindsBy(How = How.XPath, Using = "//option[contains(@value, 'expensive')]")]
        private IWebElement expensiveSort;

        [FindsBy(How = How.XPath, Using = "//app-buy-button[@class = 'toOrder ng-star-inserted']")]
        private IWebElement addToCartButton;

        public SearchResultPage(IWebDriver driver) : base(driver) { }


        public void ExpensiveSort(int timeout)
        {
            WaitVisibilityOfElement(timeout, expensiveSort);
            expensiveSort.Click();
        }

        public void AddToCartMostExpensiveProd(int timeout)
        {
            WaitVisibilityOfElement(timeout, addToCartButton);
            addToCartButton.Click();
        }
        

    }
}
