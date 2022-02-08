using NUnit.Framework;
using System.Threading;
using TestProject3.Helpers;
using TestProject3.PageObjects;

[assembly: LevelOfParallelism(3)]

namespace TestProject3.Tests
{
    
    [Parallelizable(scope: ParallelScope.All)]
    public class AddToCartTest : BaseTestSingletone
    {
        private readonly int timeoutInSeconds = 25;
        private bool CompareSum(int firtsSum, int secondSum) => firtsSum > secondSum;
        

        [Test]
        [TestCaseSource(typeof(ReadData), nameof(ReadData.TestDataIterator))]
        public void CheckCartSum(string stringInput, string sumToCompare)
        {
            PageFactoryManager pageFactoryManager = new PageFactoryManager(Driver);

            HomePage homePage = pageFactoryManager.GetHomePage(Driver);
            homePage.Search(stringInput);

            SearchResultPage searchResultPage = pageFactoryManager.GetSearchResultPage(Driver);
            searchResultPage.WaitToPageLoadComplete(timeoutInSeconds);
            searchResultPage.ExpensiveSort(timeoutInSeconds);
            Thread.Sleep(1000);
            searchResultPage.AddToCartMostExpensiveProd(timeoutInSeconds);

            CartPage cartPage = pageFactoryManager.GetCartPage(Driver);
            cartPage.OpenCart(timeoutInSeconds);
            cartPage.WaitToPageLoadComplete(timeoutInSeconds);
            int cartSum = cartPage.GetCartSum();
            Assert.IsTrue(CompareSum(cartSum, int.Parse(sumToCompare)));
        }
        



    }
}
