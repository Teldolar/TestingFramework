using System;
using System.ComponentModel;
using NUnit.Framework;
using OpenQA.Selenium.Interactions;
using Task3.Pages;
using TestFramework;
using TestFramework.Utils;

namespace Task3.Tests
{
    public class Tests : BaseTest
    {
        [Test]
        public void TestCase1()
        {
            var authPage = new AuthPage();
            DriverUtil.SetUrl($"{JsonReader.GetValueByKey("testSettings.json", "url")}{JsonReader.GetValueByKey("testSettings.json", "firstPath")}");
            Assert.AreEqual("Congratulations! You must have the proper credentials.",authPage.GetResultText(),"Wrong login or password");
            
        }
        
        [Test]
        public void TestCase2()
        {
            var alertPage = new AlertPage();
            DriverUtil.SetUrl($"{JsonReader.GetValueByKey("testSettings.json", "url")}{JsonReader.GetValueByKey("testSettings.json", "secondPath")}");
            alertPage.WaitForOpen();
            
            alertPage.ClickFirstButton();
            Assert.AreEqual("I am a JS Alert", DriverUtil.GetAlertText(),"Wrong alert");
            DriverUtil.AcceptAlert();
            Assert.AreEqual("You successfully clicked an alert",alertPage.GetResultText(),"You didn't clicked an alert");
            
            alertPage.ClickSecondButton();
            Assert.AreEqual("I am a JS Confirm", DriverUtil.GetAlertText(),"Wrong alert");
            DriverUtil.AcceptAlert();
            Assert.AreEqual("You clicked: Ok",alertPage.GetResultText(),"You didn't clicked 'Ok'");
            
            alertPage.ClickThirdButton();
            Assert.AreEqual("I am a JS prompt", DriverUtil.GetAlertText(),"Wrong alert");
            DriverUtil.InputTextToAlert("random text");
            DriverUtil.AcceptAlert();
            Assert.AreEqual("You entered: random text",alertPage.GetResultText(),"You didn't input text or clicked 'Ok'");
        }

        [Test]
        public void TestCase3()
        {
            var value = Convert.ToString(new Random().Next(0, 10)/2);
            var sliderPage = new SliderPage();
            DriverUtil.SetUrl($"{JsonReader.GetValueByKey("testSettings.json", "url")}{JsonReader.GetValueByKey("testSettings.json", "thirdPath")}");
            sliderPage.WaitForOpen();
            sliderPage.SlideForValue(value);
            Assert.AreEqual(value,sliderPage.GetSliderValue(),"Slider's value is wrong");
        }

        [Test]
        [TestCaseSource(nameof(_testCase))]
        public void TestCase4(int user)
        {
            var hoverPage = new HoverPage();
            DriverUtil.SetUrl($"{JsonReader.GetValueByKey("testSettings.json", "url")}{JsonReader.GetValueByKey("testSettings.json", "fourthPath")}");
            hoverPage.WaitForOpen();
            hoverPage.MoveCursorToUser(user);
            Assert.AreEqual($"name: user{user}",hoverPage.GetUserName(user)[..hoverPage.GetUserName(user).LastIndexOf('\r')],"Wrong user name");
            Assert.IsTrue(hoverPage.IsLinkDisplayed(user));
            hoverPage.ClickToLink(user);
            Assert.AreEqual($"{JsonReader.GetValueByKey("testSettings.json", "url")}/users/{user}",DriverUtil.GetUrl(),"Wrong user page");
            DriverUtil.Back();
            Assert.AreEqual($"{JsonReader.GetValueByKey("testSettings.json", "url")}{JsonReader.GetValueByKey("testSettings.json", "fourthPath")}",DriverUtil.GetUrl(),"User page is not open");
        }
        
        [Test]
        public void TestCase5()
        {
            var framePage = new FramePage();
            DriverUtil.SetUrl($"{JsonReader.GetValueByKey("testSettings.json", "url")}{JsonReader.GetValueByKey("testSettings.json", "fifthPath")}");
            framePage.WaitForOpen();
            framePage.AlignLeft();
            Assert.AreEqual("left",framePage.GetAlign(),"Wrong align");
            framePage.ChangeFont();
            Assert.AreEqual("10.6667px",framePage.GetFontSize(),"Wrong font size");
            framePage.NewDocument();
            Assert.AreEqual("",framePage.GetText(),"Doc is not empty");
        }
        
        private static int[] _testCase =
        {
            1,3
        };
    }
}