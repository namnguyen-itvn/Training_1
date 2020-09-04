using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Training_1.WrapperFactory;

namespace Training_1.PageObjects
{
    public static class Page 
    {
        [Obsolete]
        private static T GetPage<T>() where T : new()
        {
            T page = new T();
            PageFactory.InitElements(WebDriverFactory.Driver, page);
            return page;
        }

        [Obsolete]
        public static ForgotPasswordPage ForgotPassword => GetPage<ForgotPasswordPage>();

        [Obsolete]
        public static LoginPage Login => GetPage<LoginPage>();

        [Obsolete]
        public static CommonPage Common => GetPage<CommonPage>();

        [Obsolete]
        public static AmazonPage Amazon => GetPage<AmazonPage>();
    }
}
