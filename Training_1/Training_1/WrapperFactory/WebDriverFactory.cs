using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Training_1.Common;
using Training_1.Report;

namespace Training_1.WrapperFactory
{
    public class WebDriverFactory
    {
        private static readonly IDictionary<string, IWebDriver> Drivers = new Dictionary<string, IWebDriver>();
        protected static IWebDriver driver;
        public static ExtentReportsHelper extentReportsHelper;

        public static IWebDriver Driver
        {
            get => driver ?? throw new NullReferenceException("The WebDriver browser instance was not initialized. You should first call the method InitBrowser.");
            private set => driver = value;
        }

        public static void InitBrowser(string browserName)
        {
            driver = null;
            Drivers.Clear();
            switch (browserName)
            {
                case "Firefox":
                    if (driver == null)
                    {
                        driver = new FirefoxDriver();
                        Drivers.Add("Firefox", Driver);
                    }
                    break;
                case "Chrome":
                    if (driver == null)
                    {
                        ChromeOptions options = new ChromeOptions();
                        //options.AddArgument("--headless");
                        options.AddArgument("no-sandbox");
                        driver = new ChromeDriver(ChromeDriverService.CreateDefaultService(), options, TimeSpan.FromMinutes(ConstValue.TIMEOUT_LONG));
                        Drivers.Add("Chrome", Driver);
                    }
                    break;
                default:
                    break;
            }
            extentReportsHelper.SetStepStatusPass("Browser started.");
            //driver.Manage().Window.Maximize();
            //extentReportsHelper.SetStepStatusPass("Browser maximized.");
        }


        public static void LoadApplication(string url)
        {
            Driver.Url = url;
            extentReportsHelper.SetStepStatusPass($"Browser navigated to the url [{url}].");
            Wait();
        }

        public static void CloseAllDrivers()
        {
            foreach (string key in Drivers.Keys)
            {
                Drivers[key].Close();
                Drivers[key].Quit();
                driver = null;
            }
            extentReportsHelper.SetStepStatusPass($"Browser closed.");
            Drivers.Clear();
        }
        public static void WaitForLoad(int timeoutSec = ConstValue.TIMEOUT_LONG)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutSec));
            wait.Until(wd => js.ExecuteScript("return document.readyState").ToString() == "complete");
        }

        public static void Wait(int timeoutSec = ConstValue.TIMEOUT_SHORT)
        {
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(timeoutSec);
        }
    }
}
