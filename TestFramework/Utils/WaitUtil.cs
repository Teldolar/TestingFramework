using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using TestFramework;

namespace TestFramework.Utils
{
    public static class WaitUtil
    {
        private static readonly WebDriverWait Wait = new(BrowserFactory.GetDriver(), JsonReader.GetTimeSpanValue("appsettings.json"));

        public static void WaitUntil(bool condition)
        {
            Wait.Until(_=>condition);
        }
    }
}