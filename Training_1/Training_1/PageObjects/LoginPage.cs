using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Configuration;
using Training_1.Common;
using Training_1.TestDataAccess;
using Training_1.WrapperFactory;

namespace Training_1.PageObjects
{
    public class LoginPage
    {
        [FindsBy(How = How.Id, Using = "username")]
        public IWebElement Username { get; set; }

        [FindsBy(How = How.Id, Using = "password")]
        public IWebElement Password { get; set; }

        [FindsBy(How = How.CssSelector, Using = "[href*='forgotpassword']")]
        public IWebElement ForgotPasswordLink { get; set; }

        [FindsBy(How = How.TagName, Using = "button")]
        public IWebElement LoginButton { get; set; }

        [FindsBy(How = How.CssSelector, Using = "div.form-error")]
        public IWebElement ErrorMessage { get; set; }

        
        public string TitlePage = "test";
        public string UsernameFName = "username";
        public string PasswordFName = "password";
        public string LoginPageURL = "https://formstone.it/components/dropdown/demo/";


        public string UsernameInput = "test.abc.123";
        public string PasswordInput = "12345678";

        public void GoToURL()
        {
            WebDriverFactory.LoadApplication(ConfigurationManager.AppSettings["LoginURL"]);
        }
        public void CheckTitle()
        {
            Assert.AreEqual(TitlePage, WebDriverFactory.Driver.Title);
        }
        public void CheckPlaceholderUsernameAndPassword()
        {
            Assert.AreEqual("Username", Username.GetAttribute("placeholder"));
            Assert.AreEqual("Password", Password.GetAttribute("placeholder"));
        }

        public void CheckForgotPasswordLinkIsDisplayed()
        {
            Assert.IsTrue(ForgotPasswordLink.Displayed);
        }

        public void LoginStep(string testName)
        {
            UserData userData = DataAccess.GetTestData(testName);
            Username.SendKeys(userData.Username);
            Password.SendKeys(userData.Password);
            LoginButton.Click();
            WebDriverFactory.Wait();
        }

        public void LoginStepUseJSON()
        {
            System.Collections.Generic.List<UserData> data = DataAccess.GetTestDatasJson();
            Username.SendKeys(data[0].Username);
            Password.SendKeys(data[0].Password);
            LoginButton.Click();
            WebDriverFactory.Wait();
        }

        public void CheckErrorMassageDisplayed()
        {
            Assert.IsTrue(ErrorMessage.Displayed);
        }

        public void CheckRefreshPage()
        {
            WebDriverFactory.Driver.Navigate().Refresh();
            CheckTitle();
        }

        public void ClickForgotPassword()
        {
            ForgotPasswordLink.Click();
            WebDriverFactory.WaitForLoad(ConstValue.TIMEOUT_SHORT);
        }

        public void ForwardToNextPage()
        {
            WebDriverFactory.Driver.Navigate().Forward();
        }
    }
}
