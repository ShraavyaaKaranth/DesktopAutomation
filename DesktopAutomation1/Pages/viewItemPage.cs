using DesktopAutomation1.Drivers;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Interactions;

namespace DesktopAutomation1.Pages
{
    public class viewItemPage : BasePage
    {
        public viewItemPage() : base()
        {
            try
            {
                driver = WinAppDriverManager.GetDriver();
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                throw;
            }
        }

        public void ClickViewElement()
        {
            //var parentElement = driver.FindElementByName("SELECT SEARCH");
            //var parentLocation = parentElement.Location;
            //Console.WriteLine(parentLocation);

            //Actions actions = new Actions(driver);
            //double number = parentLocation.Y * 1.6;
            //actions.MoveToElement(parentElement).MoveByOffset(0, (int)number).Click().Perform();

            //Console.WriteLine("Successfully clicked the second button.");
            var itemelement = driver.FindElementByXPath("//*[@LocalizedControlType='window' and @Name='Lindbak POS']/Pane[4]/Pane/Custom/Custom/Custom/Button[2]");
            itemelement.Click();
        }

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

        public void clickButton(string fieldname)
        {
            var fieldbox = driver.FindElementByAccessibilityId(fieldname);
            fieldbox.Click();
        }
    }
}



//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using OpenQA.Selenium.Appium.Windows;
//using OpenQA.Selenium.Appium;
//using OpenQA.Selenium.Interactions;
//using OpenQA.Selenium;
//using System.Xml.Linq;
//using System.Drawing;

//namespace DesktopAutomation1.Pages
//{
//    public class viewItemPage : BasePage
//    {
//        public viewItemPage() : base(InitializeAppSession()) { }
//        private readonly commonPage commonPage = new();
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
//        public void ClickViewElement()
//        {
//            //// Find the parent element
//            //var parentElement = driver.FindElementByName("SELECT SEARCH");

//            //// Get the clickable point of the parent element
//            //var parentClickablePoint = new Point(4563, 1221);

//            //// Define the clickable point of the second button
//            //var secondButtonClickablePoint = new Point(4589, 1284);

//            //// Calculate the offset
//            //int offsetX = secondButtonClickablePoint.X - parentClickablePoint.X;
//            //int offsetY = secondButtonClickablePoint.Y - parentClickablePoint.Y;

//            //// Create an instance of Actions class
//            //Actions actions = new Actions(driver);

//            //// Move to the parent element and then move by the offset to click the second button
//            //actions.MoveToElement(parentElement).MoveByOffset(offsetX, offsetY).Click().Perform();

//            //Console.WriteLine("Successfully clicked the second button.");



//            // Find the parent element
//            var parentElement = driver.FindElementByName("SELECT SEARCH");

//            // Get the location of the parent element
//            var parentLocation = parentElement.Location;
//            Console.WriteLine(parentLocation);

//            // Create an instance of Actions class
//            Actions actions = new Actions(driver);
//            double number = parentLocation.Y*1.6;
//            // Move to the parent element and then move by the offset to click the second button
//            actions.MoveToElement(parentElement).MoveByOffset(0, (int)number).Click().Perform();

//            Console.WriteLine("Successfully clicked the second button.");

//        }

//        public void Send(string value, string fieldname)
//        {
//            var fieldbox = driver.FindElementByAccessibilityId(fieldname);
//            fieldbox.Click();
//            fieldbox.SendKeys(value);
//        }
//        public void clickButton(string fieldname)
//        {
//            var fieldbox = driver.FindElementByAccessibilityId(fieldname);
//            fieldbox.Click();
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
