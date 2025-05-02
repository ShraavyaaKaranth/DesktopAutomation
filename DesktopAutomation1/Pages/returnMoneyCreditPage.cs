using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace DesktopAutomation1.Pages
{
    public class returnMoneyCreditPage : BasePage
    {
        public returnMoneyCreditPage() : base() { }


        public void Send(string fieldname)
        {
            var fieldbox = driver.FindElementByAccessibilityId(fieldname);
            fieldbox.Click();
            fieldbox.SendKeys(Keys.Enter);
        }
        public void enterPrice()
        {
            //var price = driver.FindElementByAccessibilityId("FormattedAmountTextBlock");
            //var fieldbox = driver.FindElementByAccessibilityId("PaymentInput");
            //fieldbox.Click();
            //fieldbox.SendKeys(price.Text);
            //fieldbox.SendKeys(Keys.Enter);
            var price = driver.FindElementsByClassName("TextBlock");
            var fieldbox = driver.FindElementByAccessibilityId("PaymentInput");
            fieldbox.Click();
            var num = price.Count;
            fieldbox.SendKeys(price[num-1].Text);
            fieldbox.SendKeys(Keys.Enter);
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
        public void clickingButton()
        {
            var button = driver.FindElementByAccessibilityId("ValueTextBox");
            button.Click();
            button.SendKeys(Keys.Enter);
        }
    }
}
