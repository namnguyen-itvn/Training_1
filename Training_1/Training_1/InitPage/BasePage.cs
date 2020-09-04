using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Training_1.Common;
using Training_1.Report;
using Training_1.WrapperFactory;

namespace Training_1.InitPage
{
    public class BasePage
    {
        [OneTimeSetUp]
        [Obsolete]
        public void SetUpReporter()
        {
            WebDriverFactory.extentReportsHelper = new ExtentReportsHelper();
        }

        [SetUp]
        public void Open()
        {
            WebDriverFactory.extentReportsHelper.CreateTest(TestContext.CurrentContext.Test.Name);
            WebDriverFactory.InitBrowser("Chrome");
        }

        [TearDown]
        public void Close()
        {
            try
            {
                TestStatus status = TestContext.CurrentContext.Result.Outcome.Status;
                string stacktrace = TestContext.CurrentContext.Result.StackTrace;
                string errorMessage = "<pre>" + TestContext.CurrentContext.Result.Message + "</pre>";
                switch (status)
                {
                    case TestStatus.Failed:
                        WebDriverFactory.extentReportsHelper.SetTestStatusFail($"<br>{errorMessage}<br>Stack Trace: <br>{stacktrace}<br>");
                        WebDriverFactory.extentReportsHelper.AddTestFailureScreenshot(WebDriverFactory.Driver.ScreenCaptureAsBase64String());
                        break;
                    case TestStatus.Skipped:
                        WebDriverFactory.extentReportsHelper.SetTestStatusSkipped();
                        break;
                    case TestStatus.Inconclusive:
                        break;
                    case TestStatus.Passed:
                        break;
                    case TestStatus.Warning:
                        break;
                    default:
                        WebDriverFactory.extentReportsHelper.SetTestStatusPass();
                        break;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                WebDriverFactory.CloseAllDrivers();
            }
        }

        [OneTimeTearDown]
        public void CloseAll()
        {
            try
            {
                WebDriverFactory.extentReportsHelper.Close();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
