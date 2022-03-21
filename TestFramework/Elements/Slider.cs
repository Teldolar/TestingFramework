using OpenQA.Selenium;

namespace TestFramework.Elements
{
    public class Slider : BaseElement
    {
        public Slider(By locator, string name) : base(locator, name)
        {
        }
        
        public void MoveForValue(string value)
        {
            while (GetAttribute("value")!=value)
            {
                FindElement().SendKeys(Keys.ArrowRight);
            }
        }
    }
}