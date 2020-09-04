using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Training_1.WrapperFactory;

namespace Training_1.PageObjects
{
    public class DropDownPage
    {
        [FindsBy(How = How.Id, Using = "demo_basic-dropdown")]
        public IWebElement DropDown { get; set; }
        public void GoToURL()
        {
            WebDriverFactory.LoadApplication(ConfigurationManager.AppSettings["DropDownURL"]);
        }

        public void Select()
        {
        }
    }
}
