using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Training_1.InitPage;
using Training_1.PageObjects;
using Training_1.Common;
using System.Reflection.Metadata;

namespace Training_1.Tests
{
    [TestFixture]
    public class AmazonTest : BasePage
    {
        [Test, Category("Amazon_Exercise 1")]
        [Obsolete]
        public void ShouldAmazonFunctions_AreWorkWell()
        {
            Page.Amazon.GoToAmazon();
            Page.Amazon.SelectCategory("Books");
        }

        [Test, Category("Amazon_Exercise 1")]
        [Obsolete]
        public void ShouldGoToAmazonPage()
        {
            Page.Amazon.GoToAmazon();
            Page.Amazon.BrowserMaximize();
        }

        [Test, Category("Amazon_Exercise 1")]
        [Obsolete]
        public void ShouldGoToAmazonPage_DoExercise1()
        {
            Page.Amazon.GoToAmazon();
            Page.Amazon.BrowserMaximize();
            Page.Amazon.SelectCategory("Books");
            Page.Amazon.SetText(Page.Amazon.SearchBox, "Learn Selenium");
            Page.Amazon.SearchButton.Click();
            Page.Amazon.WaitForPageLoad(ConstValue.TIMEOUT_SHORT);
            Page.Amazon.ClickToElement(Page.Amazon.FirstItem);
            Page.Amazon.WaitForPageLoad(ConstValue.TIMEOUT_SHORT);
            Assert.AreEqual(Page.Amazon.ExpectedBookTitle, Page.Amazon.BookTitle.Text, "There text is not matched");
        }
    }
}
