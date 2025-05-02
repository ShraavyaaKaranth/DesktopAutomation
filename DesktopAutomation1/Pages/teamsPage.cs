using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Windows;
using DesktopAutomation1.Drivers;
using OpenQA.Selenium.Appium;
using System.Diagnostics;

namespace DesktopAutomation1.Pages
{
    public class teamsPage : BasePage
    {
        public teamsPage() : base() { }

        //private static WindowsDriver<WindowsElement> InitializeTeamsSession()
        //{
        //    var options = new AppiumOptions();
        //    options.AddAdditionalCapability("platformName", "Windows");

        //    // Try to attach to an already running Teams instance
        //    int windowHandle = Process.GetProcessesByName("ms-teams")
        //        .FirstOrDefault()?.MainWindowHandle.ToInt32() ?? 0;

        //    if (windowHandle != 0)
        //    {
        //        options.AddAdditionalCapability("appTopLevelWindow", "0x" + windowHandle.ToString("X"));
        //    }
        //    else
        //    {
        //        // If Teams is not running, launch it
        //        options.AddAdditionalCapability("app", "MSTeams_8wekyb3d8bbwe!MSTeams");
        //    }

        //    WinAppDriverManager.StartSession(options);
        //    return WinAppDriverManager.GetDriver();
        //}

        public void ClickButton(string buttonName)
        {
            driver.FindElementByXPath($"//*[contains(@Name, '{buttonName}')]").Click();
        }

        //public void SendMessage(string message)
        //{
        //    var messageBox = driver.FindElementByXPath("//*[contains(@AutomationId, 'ChatInput')]");
        //    messageBox.SendKeys(message);
        //    messageBox.SendKeys(Keys.Enter);
        //}

        //public void OpenChat(string chatName)
        //{
        //    driver.FindElementByXPath($"//*[contains(@Name, '{chatName}')]").Click();
        //}

        //public void ClickLink(string linkText)
        //{
        //    driver.FindElementByXPath($"//*[contains(@Name, '{linkText}')]").Click();
        //}
    }
}
