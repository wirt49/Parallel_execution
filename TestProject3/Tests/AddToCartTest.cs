using NUnit.Framework;
using System.Threading;
using HomeTask_Epam_2.PageObjects;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System.Xml.Linq;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using TestProject3.Helpers;

[assembly: LevelOfParallelism(3)]

namespace HomeTask_Epam_2.Tests
{
    
    [Parallelizable(scope: ParallelScope.All)]
    public class AddToCartTest : BaseTest
    {
        
        private bool CompareSum(int firtsSum, int secondSum)
        {
            return firtsSum > secondSum;
        }

        [Test]
        [TestCaseSource(typeof(ReadData), nameof(ReadData.TestDataIterator))]
        public void CheckCartSum(string stringInput, string sumToCompare)
        {
            GetHomePage().Search(stringInput);
            GetSearchResultPage().LoadComplete();
            GetSearchResultPage().ExpensiveSort();
            Thread.Sleep(1000);
            GetSearchResultPage().AddToCartMostExpensiveProd();
            
            GetCartPage().OpenCart();
            
            int cartSum = GetCartPage().GetCartSum();
            Assert.IsTrue(CompareSum(cartSum, int.Parse(sumToCompare)));
        }
        



    }
}
