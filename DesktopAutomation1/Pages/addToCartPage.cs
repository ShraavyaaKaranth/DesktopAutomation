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
    public class addToCartPage : BasePage
    {
        public addToCartPage() : base() { }

        
        public void adding(string item)
        {
            int number = int.Parse(item);
            var fieldbox = driver.FindElementsByClassName("DataGridRow");
            var grid = driver.FindElementByAccessibilityId("gridViewButton");
            grid.Click();
            var listboxitem = driver.FindElementsByClassName("ListBoxItem");

            //fieldbox.Click();
            Console.WriteLine(fieldbox.Count);
            Actions actions = new Actions(driver);
            //actions.MoveToElement(loginButton).Click().Perform();

            actions.MoveToElement(listboxitem[number-1]).Click().Perform();
        }
        public void clickButton(string fieldname)
        {
            //var fieldbox = driver.FindElementByAccessibilityId(fieldname);
            //fieldbox.Click();
        }
    }
}
