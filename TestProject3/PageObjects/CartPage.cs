using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Linq;
using System.Xml.Linq;
using System.Collections;
using SeleniumExtras.PageObjects;

namespace HomeTask_Epam_2.PageObjects
{
    public class CartPage : BasePage
    {
        readonly Int32 timeout = 10000;

        [FindsBy(How = How.XPath, Using =
            "//button[@class ='header__button ng-star-inserted header__button--active']")]
        private IWebElement cartButton;
        [FindsBy(How = How.XPath, Using = "//div[@class = 'cart-receipt__sum']/div/span")]
        private IWebElement cartSum;
        public CartPage(IWebDriver driver) : base(driver) { }

        public void OpenCart()
        {
            cartButton.Click();
        }

        public int GetCartSum()
        {
            var sum = cartSum.Text;
            int value;
            int.TryParse(string.Join("", sum.Where(c => char.IsDigit(c))), out value);
            return value;
        }

        public void LoadComplete()
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromMilliseconds(timeout));

            // Wait for the page to load
            wait.Until(d => ((IJavaScriptExecutor)d).ExecuteScript("return document.readyState").Equals("complete"));
        }

        

    }
}
