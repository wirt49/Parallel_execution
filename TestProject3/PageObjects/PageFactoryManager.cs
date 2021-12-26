using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject3.PageObjects
{
    public class PageFactoryManager
    {
        private readonly IWebDriver driver;

        public PageFactoryManager(IWebDriver driver)
        {
            this.driver = driver;
        }

        public SearchResultPage GetSearchResultPage(IWebDriver driver) => new SearchResultPage(driver);


        public HomePage GetHomePage(IWebDriver driver) => new HomePage(driver);


        public CartPage GetCartPage(IWebDriver driver) => new CartPage(driver);

    }
}
