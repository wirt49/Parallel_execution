using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;
using System;
using NUnit.Framework.Internal;
using TestProject3.PageObjects;
using System.Threading;

namespace TestProject3
{


    [TestFixture]
    public class BaseTestSingletone
    {
        private readonly string url = "https://rozetka.com.ua/";
        private static ThreadLocal<IWebDriver> driver = new ThreadLocal<IWebDriver>();



        public static IWebDriver Driver
        {
            get
            {
                if (!driver.IsValueCreated)
                {
                    throw new ArgumentException("ALLERT! Driver isn't inizialized!");
                }

                return driver.Value;
            }
        }


        public IWebDriver GetDriver() => Driver;

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
