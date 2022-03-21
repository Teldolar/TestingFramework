using System.Diagnostics.CodeAnalysis;
using OpenQA.Selenium;

namespace TestFramework.Elements
{
    public abstract class BaseElement
    {
        protected readonly By Locator;
        protected readonly string Name;

        protected BaseElement(By locator, string name)
        {
            Locator = locator;
            Name = name;
        }

        public bool IsDisplayed()
        {
            return BrowserFactory.GetDriver().FindElements(Locator).Count!=0;
        }

        public void Click()
        {
            FindElement().Click();
        }

        public string GetAttribute(string attributeName)
        {
            return FindElement().GetAttribute(attributeName);
        }

        public IWebElement FindElement()
        {
            return BrowserFactory.GetDriver().FindElement(Locator);
        }
        
        public string GetText()
        {
            return FindElement().Text;
        }

        public string GetCssValue(string key)
        {
            return FindElement().GetCssValue(key);
        }
    }
}