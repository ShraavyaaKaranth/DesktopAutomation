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
    public class paymentPage : BasePage
    {
        public paymentPage() : base() { }

        
        public void Send()
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
            fieldbox.SendKeys(price[num - 1].Text);
            fieldbox.SendKeys(Keys.Enter);
        }
        public void Clicks(string fieldname)
        {

            var fieldbox = driver.FindElementByAccessibilityId(fieldname);
            //fieldbox.Click();
            Actions actions = new Actions(driver);
            //actions.MoveToElement(loginButton).Click().Perform();

            actions.MoveToElement(fieldbox).SendKeys(Keys.Enter).Perform();
        }
    }
}
