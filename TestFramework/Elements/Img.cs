using OpenQA.Selenium;

namespace TestFramework.Elements
{
    public class Img : BaseElement
    {
        public Img(By locator, string name) : base(locator, name)
        {
        }

        public string GetAlt()
        {
            return FindElement().GetAttribute("alt");
        }
    }
}