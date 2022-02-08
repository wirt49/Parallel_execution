using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using TechTalk.SpecFlow;
using TestProject3.PageObjects;

namespace TestProject3.StepDefinitions
{



    [Binding]
    public class AddToCartStepsDefinition
    {
        public static WebDriver driver;
        public string url = "https://rozetka.com.ua/";
        private readonly int timeoutInSeconds = 25;
        [BeforeScenario]
        public static void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            PageFactoryManager pageFactoryManager = new PageFactoryManager(driver);
        }

        private bool CompareSum(int firtsSum, int secondSum) => firtsSum > secondSum;

        

        HomePage homePage = new HomePage(driver);
        SearchResultPage searchResultPage = new SearchResultPage(driver);
        CartPage cartPage = new CartPage(driver);

        [Given(@"i open homePage")]
        public void GivenIOpenHomePage()
        {
            homePage.OpenHomePage(url);
        }
        
        [When(@"i enter '(.*)' in search field")]
        public void WhenIEnterInSearchField(string laptopName)
        {
            homePage.Search(laptopName);
        }
        
        [When(@"sort the items")]
        public void WhenSortTheItems()
        {
            searchResultPage.WaitToPageLoadComplete(timeoutInSeconds);
            searchResultPage.ExpensiveSort(timeoutInSeconds);
        }
        
        [Then(@"i add the most expensive laptop to the cart")]
        public void ThenIAddTheMostExpensiveLaptopToTheCart()
        {
            searchResultPage.AddToCartMostExpensiveProd(timeoutInSeconds);
        }
        
        [Then(@"i open cart")]
        public int ThenIOpenCart()
        {
            cartPage.WaitToPageLoadComplete(timeoutInSeconds);
            cartPage.OpenCart(timeoutInSeconds);
            int cartSum = cartPage.GetCartSum();
            return cartSum;
        }
        
        [Then(@"i compare cart bill and the '(.*)'")]
        public void ThenICompareCartBillAndThe(string sum)
        {
            Assert.IsTrue(CompareSum(ThenIOpenCart(), int.Parse(sum)));
        }


        [AfterScenario]
        public static void ThrowDown()
        {
            driver.Quit();
        }
    }
}
