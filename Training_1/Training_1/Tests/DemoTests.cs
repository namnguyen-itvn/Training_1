using System;
using AventStack.ExtentReports.Model;
using NUnit.Framework;
using Training_1.InitPage;
using Training_1.PageObjects;

namespace Training_1.TestRun
{
    [Parallelizable]
    [TestFixture]
    public class DemoTests : BasePage
    {
        
        [Test, Category("SmockeTest")]
        [Obsolete]
        public void GoToPageTest_ValidateThatTheTitle_IsCorrect()
        {
            Page.Login.GoToURL();
            Page.Login.CheckTitle();
        }
        
        [Test, Category("RegressionTest"), Category("P1")]
        [Obsolete]
        public void GoToPageTest_ValidateThatTheDefaultPage()
        {
            Page.Login.GoToURL();
            Page.Login.CheckPlaceholderUsernameAndPassword();
        }

        [Test, Category("Priority=2")]
        [Obsolete]
        public void GoToPageTest_InputUsername()
        {
            Page.Login.GoToURL();
            Page.Common.CheckValueOfInput(Page.Login.UsernameFName, Page.Login.UsernameInput);
        }

        [Test, Category("Priority=2")]
        [Obsolete]
        public void GoToPageTest_InputPassword()
        {
            Page.Login.GoToURL();
            Page.Common.CheckValueOfInput(Page.Login.PasswordFName, Page.Login.PasswordInput);
        }

        [Test, Category("Priority=2")]
        [Obsolete]
        public void GoToPageTest_ValidateForgotPasswordLink_IsDisplayed()
        {
            Page.Login.GoToURL();
            Page.Login.CheckForgotPasswordLinkIsDisplayed();
        }

        [Test, Category("Priority=1")]
        [Obsolete]
        public void GoToPageTest_ValidateErrorMessage_IsDisplayed_WhenInCorrectAccount()
        {
            Page.Login.GoToURL();
            Page.Login.LoginStep("LoginTest");
            Page.Login.CheckErrorMassageDisplayed();
        }

        [Test, Category("Priority=1")]
        [Obsolete]
        public void GoToPageTest_ValidateLogin_UseJsonData()
        {
            Page.Login.GoToURL();
            Page.Login.LoginStepUseJSON();
            Page.Login.CheckErrorMassageDisplayed();
        }

        [Test, Category("Priority=2")]
        [Obsolete]
        public void GoToPageTest_ThenRefreshThisPage()
        {
            Page.Login.GoToURL();
            Page.Login.CheckRefreshPage();
        }

        [Test, Category("Priority=2")]
        [Obsolete]
        public void GoToPageTest_BackToPreviousPage()
        {
            Page.Login.GoToURL();
            Page.Login.ClickForgotPassword();
            Page.Common.CheckValidURL(Page.ForgotPassword.ForgotPasswordPageURL);
            Page.ForgotPassword.ClickCancelButton();
            Page.Common.CheckValidURL(Page.Login.LoginPageURL);
        }

        [Test, Category("Priority=2")]
        [Obsolete]
        public void GoToPageTest_ForwardToNextPage_InHistory()
        {
            Page.Login.GoToURL();
            Page.Login.ForwardToNextPage();
        }
}
}
