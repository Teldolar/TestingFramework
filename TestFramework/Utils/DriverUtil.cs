using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Opera;
using OpenQA.Selenium.Safari;
using TestFramework.Elements;

namespace TestFramework.Utils
{
    public static class DriverUtil
    {
        public static string GetAlertText()
        {
            return BrowserFactory.GetDriver().SwitchTo().Alert().Text;
        }

        public static void AcceptAlert()
        {
            BrowserFactory.GetDriver().SwitchTo().Alert().Accept();
        }

        public static void DismissAlert()
        {
            BrowserFactory.GetDriver().SwitchTo().Alert().Dismiss();
        }
        
        public static void InputTextToAlert(string text)
        {
            BrowserFactory.GetDriver().SwitchTo().Alert().SendKeys(text);
        }
        
        public static void SetUrl(string url)
        {
            BrowserFactory.GetDriver().Navigate().GoToUrl(url);
        }

        public static void MaxWindow()
        {
            BrowserFactory.GetDriver().Manage().Window.Maximize();
        }

        public static void QuitDriver()
        {
            BrowserFactory.GetDriver().Quit();
            BrowserFactory.RefreshDriver();
        }

        public static Actions CreateAction()
        {
            return new Actions(BrowserFactory.GetDriver());
        }

        public static void Back()
        {
            BrowserFactory.GetDriver().Navigate().Back();;
        }

        public static string GetUrl()
        {
            return BrowserFactory.GetDriver().Url;
        }

        public static void SwitchToFrame(string frame)
        {
            BrowserFactory.GetDriver().SwitchTo().Frame(frame);
        }

        public static void SwitchToDefault()
        {
            BrowserFactory.GetDriver().SwitchTo().DefaultContent();
        }
        
        public static void MoveCursor(BaseElement menu)
        {
            var actions = CreateAction();
            actions.MoveToElement(menu.FindElement()).Build().Perform();
        }
        
        public static void Click()
        {
            var actions = CreateAction();
            actions.Click().Build().Perform();
        }
    }
}