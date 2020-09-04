using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Training_1.Report
{
    public static class WebElementExtension
    {
        public static bool ControlDisplayed(this IWebElement element, IWebDriver driver, ExtentReportsHelper extentReportsHelper, string elementName, bool displayed = true, uint timeoutInSeconds = 60)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
            wait.IgnoreExceptionTypes(typeof(Exception));
            return wait.Until(drv =>
            {
                if ((!displayed && !element.Displayed) || (displayed && element.Displayed))
                {
                    extentReportsHelper.SetStepStatusPass($"[{elementName}] is displayed on the page.");
                    return true;

                }
                extentReportsHelper.SetStepStatusPass($"[{elementName}] is displayed on the page.");
                return false;
            });
        }
        public static void ClearWrapper(this IWebElement element, ExtentReportsHelper extentReportsHelper, string elementName)
        {
            element.Clear();
            if (element.Text.Equals(string.Empty))
            {
                extentReportsHelper.SetStepStatusPass($"Cleared element [{elementName}] content.");
            }
            else
            {
                extentReportsHelper.SetStepStatusWarning($"Element [{elementName}] content is not cleared. Element value is [{element.Text}]");
            }
        }

        [Obsolete]
        public static bool ElementlIsClickable(this IWebElement element, IWebDriver driver, ExtentReportsHelper extentReportsHelper, string elementName, uint timeoutInSeconds = 60, bool displayed = true)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
                return wait.Until(drv =>
                {
                    if (ExpectedConditions.ElementToBeClickable(element) != null)
                    {
                        extentReportsHelper.SetStepStatusPass($"Element [{elementName}] is clickable.");
                        return true;
                    }
                    extentReportsHelper.SetStepStatusWarning($"Element [{elementName}] is not clickable.");
                    return false;
                });
            }
            catch
            {
                return false;
            }
        }

        public static void SendKeysWrapper(IWebElement element, ExtentReportsHelper extentReportsHelper, string value, string elementName)
        {
            element.SendKeys(value);
            extentReportsHelper.SetStepStatusPass($"Input the  [{value}] to  element [{elementName}].");
        }
        public static bool ValidatePageTitle(IWebDriver driver, ExtentReportsHelper extentReportsHelper, string title, uint timeoutInSeconds = 300)
        {
            bool result = false;
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
            wait.IgnoreExceptionTypes(typeof(Exception));
            return result = wait.Until(drv =>
            {
                if (drv.Title.Contains(title))
                {
                    extentReportsHelper.SetStepStatusPass($"Page title [{drv.Title}] contains [{title}].");
                    return true;
                }
                extentReportsHelper.SetStepStatusWarning($"Page title [{drv.Title}] does not contain [{title}].");
                return false;
            });
        }
        public static bool ValidateURLContains(this IWebDriver driver, ExtentReportsHelper extentReportsHelper, string urlPart, uint timeoutInSeconds = 120)
        {
            bool result = false;
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
            wait.IgnoreExceptionTypes(typeof(Exception));
            return result = wait.Until(drv =>
            {
                if (drv.Url.Contains(urlPart))
                {
                    extentReportsHelper.SetStepStatusPass($"Page URL [{drv.Url}] contains [{urlPart}].");
                    return true;
                }
                extentReportsHelper.SetStepStatusWarning($"Page URL [{drv.Url}] does not contain [{urlPart}].");
                return false;
            });
        }
    }
}
