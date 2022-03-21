using System;
using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V85.IndexedDB;
using OpenQA.Selenium.Interactions;
using TestFramework;
using TestFramework.Elements;
using TestFramework.Utils;
using Key = OpenQA.Selenium.DevTools.V92.IndexedDB.Key;

namespace Task3.Pages
{
    public class InsideFramePage : BaseForm
    {
        private TextElement _text = new TextElement(By.XPath("//*[@id='tinymce']/*"), "text");
        
        private TextElement _span = new TextElement(By.XPath("//*[@id='tinymce']/p/span"), "span");
        public InsideFramePage() : base(new TextElement(By.XPath("//*[@id='tinymce']/*"),"string"), "insideFrame")
        {
            
        }

        public void ChangeFont()
        {
            Element.Click();

            var actions = DriverUtil.CreateAction();
            actions.SendKeys(Keys.Home).Build().Perform();

            actions.KeyDown(Keys.LeftShift);
            for (var i = 0; i < Convert.ToInt32(_text.GetText().Length/2); i++)
            {
                actions.SendKeys(Keys.ArrowRight);
            }

            actions.KeyUp(Keys.LeftShift);
            actions.Build().Perform();
        }

        public string GetAlign()
        {
            return _text.GetCssValue("text-align");
        }

        public string GetFontSize()
        {
            string text = _span.GetText();
            return _span.GetCssValue("font-size");
        }

        public string GetText()
        {
            return _text.GetText();
        }
    }
}