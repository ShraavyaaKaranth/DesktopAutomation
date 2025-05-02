using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesktopAutomation1.Drivers;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace DesktopAutomation1.Pages
{
    public class onlineReturnPage : BasePage
    {
        public onlineReturnPage() : base()
        {
            driver = WinAppDriverManager.GetDriver();
        }
        public void ClicksButton()
        {
            var parentElement = driver.FindElementByName("SELECT SEARCH");
            var parentLocation = parentElement.Location;
            Console.WriteLine(parentLocation);

            Actions actions = new Actions(driver);
            double number = parentLocation.Y * 6;
            actions.MoveToElement(parentElement).MoveByOffset(0, (int)number).Click().Perform();

            Console.WriteLine("Successfully clicked the second button.");
            
        }
        public void adding(int item)
        {
            var fieldbox = driver.FindElementsByClassName("DataGridRow");

            Thread.Sleep(3000);
            //fieldbox.Click();
            Console.WriteLine(fieldbox.Count);
            Actions actions = new Actions(driver);
            //actions.MoveToElement(loginButton).Click().Perform();

            actions.MoveToElement(fieldbox[item]).Click().Perform();
            actions.MoveToElement(fieldbox[item]).SendKeys(Keys.Enter).Perform();
        }

        public string switchToPopup(string popupClassName)
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

                return mainWindow;

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error switching to popup window: {ex.Message}");
                return ex.Message;
            }
        }
        public void switchToMain(string mainWindow)
        {
            // Switch back to the main window
            driver.SwitchTo().Window(mainWindow);
            Console.WriteLine("Switched back to main window.");
        }
        public void Select(int optionNumber, string popupClassName)
        {
            try
            {
                // Find and click the button inside the popup
                var button = driver.FindElementsByClassName("Button");
                button[optionNumber].Click();
                Console.WriteLine($"Clicked button on popup.");

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error handling popup: {ex.Message}");
            }
        }
    }
}
