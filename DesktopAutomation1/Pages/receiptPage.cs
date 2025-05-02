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
    public class receiptPage : BasePage
    {
        public receiptPage() : base() { }


        public void Send(string value, string fieldname)
        {
            var fieldbox = driver.FindElementByAccessibilityId(fieldname);
            fieldbox.Click();
            fieldbox.SendKeys(value);
        }
        public void Clicks(int optionNumber)
        {
            List<string> values = new List<string> { "Only print a digital receipt?", "Receipt both on paper and digitally?", "Only print a paper receipt?", "No receipt?" };
            var fieldbox = driver.FindElementByName(values[optionNumber+1]);
            //fieldbox.Click();
            Actions actions = new Actions(driver);
            //actions.MoveToElement(loginButton).Click().Perform();

            actions.MoveToElement(fieldbox).Click().Perform();
        }
    }
}
