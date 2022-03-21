using OpenQA.Selenium;
using TestFramework;
using TestFramework.Elements;
using TestFramework.Utils;

namespace Task3.Pages
{
    public class FramePage : BaseForm
    {
        private Button _alignLeft =
            new(By.XPath("//*[@id='content']/div/div/div[1]/div[1]/div[2]/div/div[4]/button[1]"), "alignLeft");
        private Button _format =
            new(By.XPath("//*[contains(text(), 'Format')]"), "format");
        private Img _sizes =
            new(By.XPath("//*[contains(text(), 'Font sizes')]"), "sizes");
        private Button _size =
            new(By.XPath("//*[text() = '8pt']"), "size");
        private Button _file =
            new(By.XPath("//*[contains(text(), 'File')]"), "file");
        private Button _newDoc =
            new(By.XPath("//*[contains(text(), 'New document')]"), "newDoc");
        
        
        private InsideFramePage _frame = new();
        
        public FramePage() : base(new Button(By.XPath("//*[@id='content']/div/div/div[1]/div[1]/div[1]/button[1]"),"File"), "iframePage")
        {
        }

        public void AlignLeft()
        {
            _alignLeft.Click();
        }
        
        public void ChangeFont()
        {
            DriverUtil.SwitchToFrame("mce_0_ifr");
            _frame.ChangeFont();
            DriverUtil.SwitchToDefault();
            _format.Click();
            DriverUtil.MoveCursor(_sizes);
            DriverUtil.MoveCursor(_size);
            DriverUtil.Click();
        }

        public string GetAlign()
        {
            DriverUtil.SwitchToFrame("mce_0_ifr");
            var align = _frame.GetAlign();
            DriverUtil.SwitchToDefault();
            return align;
        }

        public string GetFontSize()
        {
            DriverUtil.SwitchToFrame("mce_0_ifr");
            var fontSize = _frame.GetFontSize();
            DriverUtil.SwitchToDefault();
            return fontSize;
        }

        public void NewDocument()
        {
            _file.Click();
            DriverUtil.MoveCursor(_newDoc);
            DriverUtil.Click();
        }

        public string GetText()
        {
            DriverUtil.SwitchToFrame("mce_0_ifr");
            var text = _frame.GetText();
            DriverUtil.SwitchToDefault();
            return text;
        }
    }
}