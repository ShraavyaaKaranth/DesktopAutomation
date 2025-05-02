using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium;

namespace DesktopAutomation1.Pages
{
    public class popupHandler : BasePage
    {
        public  popupHandler() : base() { }

        //private static WindowsDriver<WindowsElement> InitializeAppSession()
        //{
        //    var options = new AppiumOptions();
        //    options.AddAdditionalCapability("platformName", "Windows");
        //    options.AddAdditionalCapability("deviceName", "WindowsPC");
        //    options.AddAdditionalCapability("app", @"C:\Users\shkar\Desktop\testExec\Automation\Lindbak POS.exe");

        //    Console.WriteLine("Launching application...");
        //    var driver = new WindowsDriver<WindowsElement>(new Uri("http://127.0.0.1:4723"), options);
        //    //Thread.Sleep(8000); // Wait for the app to load

        //    return driver;
        //}
        public void acceptPopup(string popupClassName, string buttonAccessibilityId)
        {
            try
            {
                Thread.Sleep(3000);
                string mainWindow = driver.CurrentWindowHandle;

                // Find and switch to the popup window
                foreach (string window in driver.WindowHandles)
                {
                    if (window != mainWindow)
                    {
                        driver.SwitchTo().Window(window);
                        Console.WriteLine($"Switched to popup window: {popupClassName}");
                        break;
                    }
                }

                // Find and click the button inside the popup
                var button = driver.FindElementByAccessibilityId(buttonAccessibilityId);
                button.Click();
                Console.WriteLine($"Clicked button '{buttonAccessibilityId}' on popup.");

                // Switch back to the main window
                driver.SwitchTo().Window(mainWindow);
                Console.WriteLine("Switched back to main window.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error handling popup: {ex.Message}");
            }
        }


    }
}
