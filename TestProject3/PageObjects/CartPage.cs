using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Linq;
using System.Xml.Linq;
using System.Collections;
using SeleniumExtras.PageObjects;

namespace TestProject3.PageObjects
{
    public class CartPage : BasePage
    {
        [FindsBy(How = How.XPath, Using =
            "//button[@class ='header__button ng-star-inserted header__button--active']")]
        private readonly IWebElement cartButton;

        [FindsBy(How = How.XPath, Using = "//div[@class = 'cart-receipt__sum']/div/span")]
        private readonly IWebElement cartSum;

        public CartPage(IWebDriver driver) : base(driver) { }

        public void OpenCart(int timeout)
        {
            WaitVisibilityOfElement(timeout, cartButton);
            cartButton.Click();
        }

        public int GetCartSum()
        {
            var sum = cartSum.Text;
            int.TryParse(string.Join("", sum.Where(c => char.IsDigit(c))), out int value);
            return value;
        }

        

        

    }
}
