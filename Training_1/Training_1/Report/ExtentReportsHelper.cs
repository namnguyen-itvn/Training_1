using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Training_1.Report
{
    public class ExtentReportsHelper

    {
        public ExtentReports Extent { get; set; }
        [Obsolete]
        public ExtentV3HtmlReporter Reporter { get; set; }
        public ExtentTest Test { get; set; }

        [Obsolete]
        public ExtentReportsHelper()
        {
            Extent = new ExtentReports();
            Reporter = new ExtentV3HtmlReporter(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Reports/ExtentReports.html"));
            Reporter.Config.DocumentTitle = "Automation Testing Report";
            Reporter.Config.ReportName = "Regression Testing";
            Reporter.Config.Theme = AventStack.ExtentReports.Reporter.Configuration.Theme.Standard;
            Extent.AttachReporter(Reporter);
            Extent.AddSystemInfo("Application Under Test", "nop Commerce Demo");
            Extent.AddSystemInfo("Environment", "QA");
            Extent.AddSystemInfo("Machine", Environment.MachineName);
            Extent.AddSystemInfo("OS", Environment.OSVersion.VersionString);
        }
        public void CreateTest(string testName)
        {
            Test = Extent.CreateTest(testName);
        }
        public void SetStepStatusPass(string stepDescription)
        {
            Test.Log(Status.Pass, stepDescription);
        }
        public void SetStepStatusWarning(string stepDescription)
        {
            Test.Log(Status.Warning, stepDescription);
        }
        public void SetTestStatusPass()
        {
            Test.Pass("Test Executed Sucessfully!");
        }

        public void SetTestStatusFail(string message = null)
        {
            string printMessage = "<p><b>Test FAILED!</b></p>";
            if (!string.IsNullOrEmpty(message))
            {
                printMessage += $"Message: <br>{message}<br>";
            }
            Test.Fail(printMessage);
        }
        public void AddTestFailureScreenshot(string base64ScreenCapture)
        {
            Test.AddScreenCaptureFromBase64String(base64ScreenCapture, "Screenshot on Error:");
        }
        public void SetTestStatusSkipped()
        {
            Test.Skip("Test skipped!");
        }
        public void Close()
        {
            Extent.Flush();
        }

    }
}
