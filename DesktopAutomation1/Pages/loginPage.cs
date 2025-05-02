    using OpenQA.Selenium;
    using OpenQA.Selenium.Appium.Windows;
    using OpenQA.Selenium.Interactions;

    namespace DesktopAutomation1.Pages
    {
        public class loginPage : BasePage
        {
            public loginPage() : base() { }

            public void Send(string value, string fieldname)
            {
                var fieldbox = driver.FindElementByAccessibilityId(fieldname);
                fieldbox.Click();
                fieldbox.SendKeys(value);
            }

            public void Clicks(string fieldname)
            {
                var fieldbox = driver.FindElementsByClassName(fieldname);
                Actions actions = new Actions(driver);
                actions.MoveToElement(fieldbox[0]).SendKeys(Keys.Enter).Perform();
            }
        }
    }




//using OpenQA.Selenium;
//using OpenQA.Selenium.Appium.Windows;
//using OpenQA.Selenium.Interactions;

//namespace DesktopAutomation1.Pages
//{
//    public class loginPage : BasePage
//    {
//        public loginPage() : base() { }

//        public void Send(string value, string fieldname)
//        {
//            var fieldbox = driver.FindElementByAccessibilityId(fieldname);
//            fieldbox.Click();
//            fieldbox.SendKeys(value);
//        }

//        public void Clicks(string fieldname)
//        {
//            var fieldbox = driver.FindElementsByClassName(fieldname);
//            Actions actions = new Actions(driver);
//            actions.MoveToElement(fieldbox[0]).SendKeys(Keys.Enter).Perform();
//        }
//    }
//}






//using System;
//using System.Diagnostics;
//using System.Threading;
//using OpenQA.Selenium.Appium;
//using OpenQA.Selenium.Appium.Windows;
//using OpenQA.Selenium;
//using static System.Net.Mime.MediaTypeNames;
//using OpenQA.Selenium.Interactions;

//namespace DesktopAutomation1.Pages
//{
//    public class loginPage : BasePage
//    {
//        public loginPage() : base(InitializeAppSession()) { }

//        private static WindowsDriver<WindowsElement> InitializeAppSession()
//        {
//            var options = new AppiumOptions();
//            options.AddAdditionalCapability("platformName", "Windows");
//            options.AddAdditionalCapability("deviceName", "WindowsPC");
//            options.AddAdditionalCapability("app", @"C:\Users\shkar\Desktop\testExec\Automation\Lindbak POS.exe");

//            Console.WriteLine("Launching application...");
//            var driver = new WindowsDriver<WindowsElement>(new Uri("http://127.0.0.1:4723"), options);
//            //Thread.Sleep(8000); // Wait for the app to load

//            return driver;
//        }

//        public void Send(string value, string fieldname)
//        {
//            var fieldbox = driver.FindElementByAccessibilityId(fieldname);
//            fieldbox.Click();
//            fieldbox.SendKeys(value);
//        }
//        public void Clicks(string fieldname)
//        {
//            var fieldbox = driver.FindElementsByClassName(fieldname);
//            //fieldbox.Click();
//            Actions actions = new Actions(driver);
//            //actions.MoveToElement(loginButton).Click().Perform();

//            actions.MoveToElement(fieldbox[0]).SendKeys(Keys.Enter).Perform();
//        }
//    }
//}
