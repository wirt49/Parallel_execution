using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;
using System;
using NUnit.Framework.Internal;
using HomeTask_Epam_2.PageObjects;
using System.Threading;

namespace HomeTask_Epam_2
{


    [TestFixture]
    public class BaseTest
    {
        //protected IWebDriver driver;
        private readonly string url = "https://rozetka.com.ua/";
        private static ThreadLocal<IWebDriver> driver = new ThreadLocal<IWebDriver>();



        public static IWebDriver Driver
        {
            get
            {
                if (!driver.IsValueCreated)
                {
                    throw new ArgumentException("ALLERT!");
                }

                return driver.Value;
            }
        }


        public IWebDriver GetDriver()
        {
            return Driver;
        }

        public SearchResultPage GetSearchResultPage()
        {
            return new SearchResultPage(Driver);
        }

        public HomePage GetHomePage()
        {
            return new HomePage(Driver);
        }

        public CartPage GetCartPage()
        {
            return new CartPage(Driver);
        }


        [SetUp]
        public void Setup()
        {
            driver.Value = new ChromeDriver();

            Driver.Navigate().GoToUrl(url);
            Driver.Manage().Window.Maximize();
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(100);

        }

        [TearDown]
        public void TearDown()
        {
            Driver.Quit();
        }
    }
}
