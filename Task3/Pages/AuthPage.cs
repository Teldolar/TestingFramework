using OpenQA.Selenium;
using TestFramework;
using TestFramework.Elements;

namespace Task3.Pages
{
    public class AuthPage : BaseForm
    {
        public AuthPage() : base(new TextElement(By.CssSelector("p"),"result"), "authPage")
        {
        }

        public string GetResultText()
        {
            return Element.GetText();
        }
    }
}