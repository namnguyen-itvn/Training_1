using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Training_1.Report
{
    public static class WebDiverExtensions
    {
        public static string ScreenCaptureAsBase64String(this IWebDriver driver)
        {
            ITakesScreenshot ts = (ITakesScreenshot)driver;
            Screenshot screenshot = ts.GetScreenshot();
            return screenshot.AsBase64EncodedString;
        }
    }
}
