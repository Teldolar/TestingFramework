using OpenQA.Selenium;
using TestFramework;
using TestFramework.Elements;

namespace Task3.Pages
{
    public class AlertPage : BaseForm
    {
        private readonly Button _secondButton = new (By.XPath("//button[.='Click for JS Confirm']"),"second button");
        private readonly Button _thirdButton = new (By.XPath("//button[.='Click for JS Prompt']"),"second button");

        private readonly TextElement _result = new (By.XPath("//*[@id='result']"),"result");
        
        public AlertPage() : base(new Button(By.XPath("//button[.='Click for JS Alert']"),"first button") , "alertPage")
        {
        }

        public void ClickFirstButton()
        {
            Element.Click();
        }
        
        public void ClickSecondButton()
        {
            _secondButton.Click();
        }
        
        public void ClickThirdButton()
        {
            _thirdButton.Click();
        }

        public string GetResultText()
        {
            return _result.GetText();
        }
    }
}