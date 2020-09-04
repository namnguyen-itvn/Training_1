using AventStack.ExtentReports.Model;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Training_1.Report;
using Training_1.WrapperFactory;

namespace Training_1.PageObjects
{
    public class CommonPage : WebDriverFactory
    {

        public void CheckValueOfInput(string fieldName, string value)
        {
            IWebElement field = driver.FindElement(By.Id(fieldName));
            WebElementExtension.SendKeysWrapper(field, extentReportsHelper, value, fieldName);
            Assert.AreEqual(value, field.GetAttribute("value"));
        }

        public void CheckValidURL(string expectedURL)
        {
            Assert.AreEqual(expectedURL, Driver.Url);
        }
    }
}
