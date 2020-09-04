using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using Training_1.Common;
using Training_1.TestDataAccess;
using Training_1.WrapperFactory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using System.Configuration;
using Training_1.Report;
using RazorEngine.Compilation.ImpromptuInterface.Dynamic;
using OpenQA.Selenium.Interactions;

namespace Training_1.PageObjects
{

    
    public class AmazonPage
    {

        public static ExtentReportsHelper extentReportsHelper;

        #region Define WebElement

        public string AmazonUrl = ConfigurationManager.AppSettings["AmazonSite"];

        public string AmazonPageTitle = "Amazon.com: Online Shopping for Electronics, Apparel, Computers, Books, DVDs & more";

        [FindsBy(How = How.CssSelector, Using = "div[class*='nav-search-scope']")]
        public IWebElement SearchDropdown { get; set; }

        [FindsBy(How = How.CssSelector, Using = "div[class*='nav-search-scope'] select")]
        public IWebElement ListItems { get; set; }

        [FindsBy(How = How.Id, Using = "twotabsearchtextbox")]
        public IWebElement SearchBox { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@type='submit']")]
        public IWebElement SearchButton { get; set; }

        [FindsBy(How = How.CssSelector, Using = "img[alt='Learn Selenium: Build data-driven test frameworks for mobile and web applications with Selenium Web Driver 3']")]
        public IWebElement FirstItem { get; set; }

        [FindsBy(How = How.Id, Using = "productTitle")]
        public IWebElement BookTitle { get; set; }
        public string ExpectedBookTitle = "Learn Selenium: Build data-driven test frameworks for mobile and web applications with Selenium Web Driver 3";


        #endregion

        #region Define Funtion

        public void SelectCategory(string _book)
        {
            SearchDropdown.Click();
            SelectElementBy(ListItems, SelectType.SelectByText, _book);
        }

        public string GetCurrentPageTitle()
        {
            return WebDriverFactory.Driver.Title;
        }
        public void GoToAmazon()
        {
            WebDriverFactory.Driver.Navigate().GoToUrl(AmazonUrl);
            if (WebDriverFactory.Driver.Title.Equals(AmazonPageTitle) == true)
            {
                WebDriverFactory.Driver.Navigate().GoToUrl(AmazonUrl);
            }
        }

        #endregion

        #region Define Keywork


        #region Click
        public void ClickToElement(IWebElement element)
        {
            ElementlIsClickable(element);
            element.Click();
        }
        #endregion

        #region ElementlIsClickable
        public static bool ElementlIsClickable(IWebElement element, uint timeoutInSeconds = 60, bool displayed = true)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(WebDriverFactory.Driver, TimeSpan.FromSeconds(timeoutInSeconds));
                return wait.Until(drv =>
                {
                    if (ExpectedConditions.ElementToBeClickable(element) != null)
                    {
                        extentReportsHelper.SetStepStatusPass($"Element is clickable.");
                        return true;
                    }
                    extentReportsHelper.SetStepStatusWarning($"Element is not clickable.");
                    return false;
                });
            }
            catch
            {
                return false;
            }
        }
        #endregion

        #region WaitElementVisible
        public void WaitElementVisible(By locatorValue, int timeOut)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(WebDriverFactory.Driver, TimeSpan.FromSeconds(timeOut));
                wait.Until(ExpectedConditions.ElementIsVisible(locatorValue));
            }
            catch (WebDriverTimeoutException e)
            {
                throw new OperationCanceledException("Get " + e.Message + ", " + locatorValue + " is not visible");
            }
        }
        #endregion

        #region GetAttribute
        public string GetAttribute(IWebElement element, string attribute)
        {
            return element.GetAttribute(attribute);
        }
        #endregion

        #region GetPageSource
        public string GetPageSource()
        {
            return WebDriverFactory.Driver.PageSource;
        }
        #endregion

        #region GetCssValue
        public string GetCssValue(IWebElement element, string value)
        {
            return element.GetCssValue(value);
        }
        #endregion

        #region SetText
        public void SetText(IWebElement element, string text)
        {
            try
            {
                element.Clear();
                element.SendKeys(text);
            }
            catch (WebDriverException e)
            {
                throw new Exception("Element is not enable for set text" + "\r\n" + "error: " + e.Message);
            }

        }
        #endregion

        #region BrowserMaximize
        public void BrowserMaximize()
        {
            WebDriverFactory.Driver.Manage().Window.Maximize();
        }
        #endregion

        #region WaitForPageLoad
        public void WaitForPageLoad(int time)
        {
            TimeSpan timeout = new TimeSpan(0, 0, time);
            WebDriverWait wait = new WebDriverWait(WebDriverFactory.Driver, timeout);
            if (!(WebDriverFactory.Driver is IJavaScriptExecutor javascript))
            {
                throw new ArgumentException("driver", "Driver must support javascript execution");
            }
            wait.Until((d) =>
            {
                try
                {
                    return javascript.ExecuteScript("return document.readyState").Equals("complete");
                }
                catch (InvalidOperationException e)
                {
                    //Window is no longer available
                    return e.Message.ToLower().Contains("Unable to driver browser");
                }
                catch (WebDriverException e)
                {
                    //Browser is no longer available
                    return e.Message.ToLower().Contains("Unable to connect");
                }
                catch (Exception)
                {
                    return false;
                }
            });
        }
        #endregion

        #region SelectElementBy
        public void SelectElementBy(IWebElement element, SelectType type, string options)
        {
            SelectElement select = new SelectElement(element);
            switch (type)
            {
                case SelectType.SelectByIndex:
                    try
                    {
                        select.SelectByIndex(int.Parse(options));
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.GetBaseException().ToString());
                        throw new ArgumentException("Please input numberic on selectOption for SelectType.SelectByIndex");
                    }
                    break;
                case SelectType.SelectByText:
                    select.SelectByText(options);
                    break;
                case SelectType.SelectByValue:
                    select.SelectByValue(options);
                    break;
                default:
                    throw new Exception("Get error in using Selected");
            }
        }
        #endregion

        #endregion
        public enum SelectType
        {
            SelectByIndex,
            SelectByText,
            SelectByValue,
        }
    }
}
