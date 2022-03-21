using OpenQA.Selenium;

namespace TestFramework.Elements
{
    public class TextElement : BaseElement
    {
        public TextElement(By locator, string name) : base(locator, name)
        {
        }

        public void SendKeys(string key)
        {
            FindElement().SendKeys(key);
        }
    }
}