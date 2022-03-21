using OpenQA.Selenium;
using TestFramework.Elements;
using TestFramework.Utils;

namespace TestFramework
{
    public abstract class BaseForm
    {
        protected readonly BaseElement Element;
        protected readonly string Name;

        protected BaseForm(BaseElement element, string name)
        {
            Element = element;
            Name = name;
        }

        private bool IsDisplayed()
        {
            return Element.IsDisplayed();
            
        }

        public void WaitForOpen()
        {
            WaitUtil.WaitUntil(IsDisplayed());
        }
    }
}