using System.Runtime.CompilerServices;
using DesktopAutomation1.Drivers;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;

namespace DesktopAutomation1.Pages
{
    public class CalculatorPage : BasePage
    {
        public CalculatorPage() : base() { }

        //private static WindowsDriver<WindowsElement> InitializeCalculatorSession()
        //{
        //    var options = new AppiumOptions();
        //    options.AddAdditionalCapability("platformName", "Windows");
        //    options.AddAdditionalCapability("app", "Microsoft.WindowsCalculator_8wekyb3d8bbwe!App");

        //    WinAppDriverManager.StartSession(options);
        //    return WinAppDriverManager.GetDriver();
        //}

        public void ClickNumber(int number)
        {
            driver.FindElementByAccessibilityId("num" + number + "Button").Click();
        }

        public void ClickPlus()
        {
            driver.FindElementByName("Plus").Click();
        }

        public void ClickEquals()
        {
            driver.FindElement(By.Name("Equals")).Click();
        }

        public string GetResult()
        {
            var resultElement = driver.FindElementByAccessibilityId("CalculatorResults");
            Console.WriteLine(resultElement.Text.Replace("Display is", "").Trim());
            return resultElement.Text.Replace("Display is", "").Trim();
        }
    }
}
