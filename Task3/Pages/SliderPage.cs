using OpenQA.Selenium;
using TestFramework;
using TestFramework.Elements;

namespace Task3.Pages
{
    public class SliderPage : BaseForm
    {
        private readonly Slider _slider = new(By.XPath("//*[@id='content']/div/div/input"),"slider");
        
        public SliderPage() : base(new Slider(By.XPath("//*[@id='content']/div/div"),"sliderContainer"), "sliderPage")
        {
            
        }

        public void SlideForValue(string value)
        {
            _slider.MoveForValue(value);
        }

        public string GetSliderValue()
        {
            return _slider.GetAttribute("value");
        }
    }
}