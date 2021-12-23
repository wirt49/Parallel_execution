using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
namespace HomeTask_Epam_2.PageObjects
{

    public class BasePage
    {
        protected IWebDriver driver;

        public BasePage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }
    }
}
