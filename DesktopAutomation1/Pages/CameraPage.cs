//using OpenQA.Selenium;
//using OpenQA.Selenium.Support.UI;
//using OpenQA.Selenium.Appium.Windows;
//using DesktopAutomation1.Drivers;
//using System;
//using OpenQA.Selenium.Appium;

//namespace DesktopAutomation1.Pages
//{
//    public class CameraPage : BasePage
//    {
//        public CameraPage() : base() { }

//        //private static WindowsDriver<WindowsElement> InitializeCameraSession()
//        //{
//        //    var options = new AppiumOptions();
//        //    options.AddAdditionalCapability("platformName", "Windows");
//        //    options.AddAdditionalCapability("app", "Microsoft.WindowsCamera_8wekyb3d8bbwe!App");

//        //    WinAppDriverManager.StartSession(options);
//        //    return WinAppDriverManager.GetDriver();
//        //}

//        public void Toggle()
//        {
//            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(8));
//            Thread.Sleep(3000);
//            var switchButton = wait.Until(d => driver.FindElementByAccessibilityId("CaptureButton_0"));

//            if (switchButton.Text.Contains("Switch to photo mode"))
//            {
//                switchButton.Click();
//                Console.WriteLine("Switched to Photo Mode.");
//            }
//        }

//        public void Capture()
//        {
//            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
//            var captureButton = wait.Until(d => driver.FindElementByAccessibilityId("CaptureButton_0"));

//            if (captureButton.Text.Contains("Take photo"))
//            {
//                captureButton.Click();
//                Console.WriteLine("Photo Captured!");
//            }
//        }
//    }
//}
