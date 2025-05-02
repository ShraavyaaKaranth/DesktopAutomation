using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Interactions;
using DesktopAutomation1.Drivers;
using OpenQA.Selenium;

namespace DesktopAutomation1.Pages
{
    public class receiptTabPage : BasePage
    {
        public receiptTabPage() : base()
        {
            driver = WinAppDriverManager.GetDriver();
        }

        public void Send(string value, string fieldname)
        {
            var fieldbox = driver.FindElementByAccessibilityId(fieldname);
            fieldbox.Click();
            fieldbox.SendKeys(value);
        }
        public void Clicks(string fieldname)
        {

            var fieldbox = driver.FindElementByAccessibilityId(fieldname);
            //fieldbox.Click();
            Actions actions = new Actions(driver);
            //actions.MoveToElement(loginButton).Click().Perform();

            actions.MoveToElement(fieldbox).SendKeys(Keys.Enter).Perform();
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

        public void EnterValidReceipt(int optionNumber, string value)
        {
            var editArea = driver.FindElementsByAccessibilityId("ValueTextBox").ToList();
            editArea[optionNumber].Click();
            editArea[optionNumber].SendKeys(value);
            editArea[optionNumber].SendKeys(Keys.Enter);
            Console.WriteLine($"Clicked button on popup.");
        }

        public void ClickReceiptElement()
        {
            //var parentElement = driver.FindElementByName("SELECT SEARCH");
            //var parentLocation = parentElement.Location;
            //Console.WriteLine(parentLocation);

            //Actions actions = new Actions(driver);
            //double number = parentLocation.Y * 3;
            //actions.MoveToElement(parentElement).MoveByOffset(0, (int)number).Click().Perform();

            //Console.WriteLine("Successfully clicked the second button.");
            var receiptButton = driver.FindElementByXPath("//*[@LocalizedControlType='window' and @Name='Lindbak POS']/Pane[4]/Pane/Custom/Custom/Custom/Button[5]");
            receiptButton.Click();
        }
    }
}
