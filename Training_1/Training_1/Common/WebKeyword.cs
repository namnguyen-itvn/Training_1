using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Training_1.Common
{
    public class WebKeyword
    {
        public WebKeyword SelectElement(IWebElement element, SelectType type, string options)
        {
            SelectElement select = new SelectElement(element);
            switch (type)
            {
                case SelectType.SelectByIndex:
                    try
                    {
                        select.SelectByIndex(Int32.Parse(options));
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
            return this;
        }

        public enum SelectType
        {
            SelectByIndex,
            SelectByText,
            SelectByValue,
        }
    }
}
