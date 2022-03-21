using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using TestFramework;
using TestFramework.Elements;
using TestFramework.Utils;

namespace Task3.Pages
{
    public class HoverPage : BaseForm
    {
        private readonly Img _firstProfile = new(By.XPath("//*[@id='content']/div/div[1]/img"),"firstProfile" );
        private readonly Img _secondProfile = new(By.XPath("//*[@id='content']/div/div[2]/img"),"secondProfile" );
        private readonly Img _thirdProfile = new(By.XPath("//*[@id='content']/div/div[3]/img"),"thirdProfile" );

        private readonly Link _firstLink = new(By.XPath("//*[@id='content']/div/div[1]/div/a"),"firstUserLink");
        private readonly Link _secondLink = new(By.XPath("//*[@id='content']/div/div[2]/div/a"),"firstUserLink");
        private readonly Link _thirdLink = new(By.XPath("//*[@id='content']/div/div[3]/div/a"),"firstUserLink");
        
        private readonly TextElement _firstName = new(By.XPath("//*[@id='content']/div/div[1]/div"),"firstUserName");
        private readonly TextElement _secondName = new(By.XPath("//*[@id='content']/div/div[2]/div"),"firstUserName");
        private readonly TextElement _thirdName = new(By.XPath("//*[@id='content']/div/div[3]/div"),"firstUserName");
        
        public HoverPage() : base(new TextElement(By.XPath("//*[@id='content']/div/p"),"description"), "HoverPage")
        {
        }

        public void MoveCursorToUser(int userNumber)
        {
            switch (userNumber)
            {
                case 1:
                    MoveCursor(_firstProfile);
                    break;
                case 2:
                    MoveCursor(_secondProfile);
                    break;
                case 3:
                    MoveCursor(_thirdProfile);
                    break;
                default:
                    throw new Exception("Wrong user number");
            }
            
        }

        private static void MoveCursor(BaseElement user)
        {
            var actions = DriverUtil.CreateAction();
            actions.MoveToElement(user.FindElement()).Build().Perform();
        }

        public void ClickToLink(int userNumber)
        {
            switch (userNumber)
            {
                case 1:
                    _firstLink.Click();
                    break;
                case 2:
                    _secondLink.Click();
                    break;
                case 3:
                    _thirdLink.Click();
                    break;
                default:
                    throw new Exception("Wrong user number");
            }
        }

        public bool IsLinkDisplayed(int linkNumber)
        {
            return linkNumber switch
            {
                1 => _firstLink.IsDisplayed(),
                2 => _secondLink.IsDisplayed(),
                3 => _thirdLink.IsDisplayed(),
                _ => throw new Exception("Wrong user number")
            };
        }

        public string GetUserName(int user)
        {
            return user switch
            {
                1 => _firstName.GetText(),
                2 => _secondName.GetText(),
                3 => _thirdName.GetText(),
                _ => throw new Exception("Wrong user number")
            };
        }
    }
}