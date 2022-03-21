using System;
using System.Diagnostics;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Opera;
using OpenQA.Selenium.Safari;
using TestFramework.Utils;
using WebDriverManager.DriverConfigs.Impl;

namespace TestFramework
{
    public static class BrowserFactory
    {
        private static IWebDriver _driver;
        

        public static IWebDriver GetDriver()
        {
            if (_driver != null) return _driver;
            _driver = JsonReader.GetValueByKey("appsettings.json", "browser") switch
            {
                "Chrome" => new ChromeDriver(GetChromeOptions()),
                "Firefox" => new FirefoxDriver(GetFirefoxOptions()),
                _ => throw new Exception("Wrong browser setup")
            };
            return _driver;
        }
        
        private static void SetLanguage(ref ChromeOptions options)
        {
            options.AddArgument($"--lang={JsonReader.GetValueByKey("appsettings.json","language")}");
        }
        private static void SetLanguage(ref FirefoxOptions options)
        {
            options.SetPreference("intl.accept_languages",JsonReader.GetValueByKey("appsettings.json","language"));
        }

        private static ChromeOptions GetChromeOptions()
        {
            new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
            var options = new ChromeOptions();
            SetLanguage(ref options);
            return options;
        }
        
        private static FirefoxOptions GetFirefoxOptions()
        {
            new WebDriverManager.DriverManager().SetUpDriver(new FirefoxConfig());
            var options = new FirefoxOptions();
            SetLanguage(ref options);
            return options;
        }

        public static void RefreshDriver()
        {
            _driver = null;
        }
    }
}