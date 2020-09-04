using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Training_1.Common;
using Training_1.WrapperFactory;

namespace Training_1.PageObjects
{
    
    public class ForgotPasswordPage
    { 
        //public ForgotPasswordPage(IWebDriver driver)
        //{
        //    this.driver = driver;
        //}


        [FindsBy(How = How.TagName, Using = "legend")]
        public IWebElement ForgotPasswordTitle { get; set; }

        [FindsBy(How = How.CssSelector, Using = "a.btn.btn-cancel")]
        public IWebElement CancelButton { get; set; }

        public string ForgotPasswordPageURL = "https://formstone.it/components/dropdown/demo/";

        public void CheckForgotPasswordTitleIsDisplayed()
        {
            Assert.IsTrue(ForgotPasswordTitle.Displayed);
        }

        public void ClickCancelButton()
        {
            CancelButton.Click();
            WebDriverFactory.WaitForLoad(ConstValue.TIMEOUT_SHORT);
        }
    }
}
