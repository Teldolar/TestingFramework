using OpenQA.Selenium;

namespace TestFramework.Elements
{
    public class TextField : BaseElement
    {
        protected TextField(By locator, string name) : base(locator,name)
        {
            
        }

        public void SendText(string text)
        {
            BrowserFactory.GetDriver().FindElement(Locator).SendKeys(text);
        }
    }
}