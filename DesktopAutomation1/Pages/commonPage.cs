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
    public class commonPage : BasePage
    {
        public commonPage() : base() { }

        
        public void Clicks(string fieldname)
        {
            var fieldbox = driver.FindElementByAccessibilityId(fieldname);
            //fieldbox.Click();
            Actions actions = new Actions(driver);
            //actions.MoveToElement(loginButton).Click().Perform();

            actions.MoveToElement(fieldbox).SendKeys(Keys.Enter).Perform();
        }
        public void ClickClass(string fieldname)
        {
            var fieldbox = driver.FindElementByClassName(fieldname);
            //fieldbox.Click();
            Actions actions = new Actions(driver);
            //actions.MoveToElement(loginButton).Click().Perform();

            actions.MoveToElement(fieldbox, 0, 0).Click().Perform();
        }

        public void Send(string value, string fieldname)
        {

            var fieldbox = driver.FindElementByAccessibilityId(fieldname);
            fieldbox.Click();
            fieldbox.SendKeys(value);
            //fieldbox.SendKeys(Keys.Enter);
        }

        //public void ClickClassItem(string fieldname, string fieldnumber)
        //{
        //    int number = Convert.ToInt32(fieldnumber);
        //    var fieldboxes = driver.FindElementsByClassName(fieldname);
        //    var loginButton = fieldboxes[number];
        //    Actions actions = new Actions(driver);
        //    //actions.MoveToElement(loginButton).Click().Perform();

        //    actions.MoveToElement(loginButton).SendKeys(Keys.Enter).Perform();
        //    //Console.WriteLine($"{fieldname} {fieldbox.TagName}");
        //    //fieldbox.Click();
        //    //fieldbox.SendKeys(Keys.Enter);
        //}
        public void ClickClassItem(string combinedClassNames, string fieldnumber)
        {
            int number = Convert.ToInt32(fieldnumber);

            // Split the combined class names using the delimiter ","
            var classNames = combinedClassNames.Split(',');

            // Find the parent element if there are multiple class names
            var parentElement = classNames.Length > 1
                ? driver.FindElementByClassName(classNames[0])
                : null;

            // Find the child elements within the parent element if there are multiple class names
            var childElements = classNames.Length > 1
                ? parentElement.FindElements(By.ClassName(classNames[1])).Cast<IWebElement>().ToList()
                : driver.FindElements(By.ClassName(classNames[0])).Cast<IWebElement>().ToList();

            // Get the specific child element by index
            var targetElement = childElements[number];

            // Perform the action on the target element
            Actions actions = new Actions(driver);
            actions.MoveToElement(targetElement).SendKeys(Keys.Enter).Perform();
        }
        public void pressKeys(string key, string fieldname)
        {
            var fieldbox = driver.FindElementByAccessibilityId(fieldname);
            //fieldbox.Click();
            Actions actions = new Actions(driver);
            //actions.MoveToElement(loginButton).Click().Perform();

            actions.MoveToElement(fieldbox).SendKeys(key).Perform();
        }
    }
}
