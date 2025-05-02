using OpenQA.Selenium.Appium.Windows;
using DesktopAutomation1.Drivers;
using DesktopAutomation1.Config;

namespace DesktopAutomation1.Pages
{
    public class BasePage
    {
        protected WindowsDriver<WindowsElement> driver;

        public BasePage()
        {
            //driver = WinAppDriverManager.GetDriver();
            driver = WinAppDriverManager.GetDriver();

        }
    }
}



//using DesktopAutomation1.Drivers;
//using OpenQA.Selenium.Appium.Windows;

//namespace DesktopAutomation1.Pages
//{
//    public class BasePage
//    {
//        protected WindowsDriver<WindowsElement> driver;

//        public BasePage()
//        {
//            driver = WinAppDriverManager.GetDriver();
//        }
//    }
//}




//using OpenQA.Selenium.Appium.Windows;
//using OpenQA.Selenium.Appium;
//using OpenQA.Selenium.Remote;
//using System;

//using DesktopAutomation1.Drivers;

//namespace DesktopAutomation1.Pages
//{
//    public class BasePage
//    {
//        protected WindowsDriver<WindowsElement> driver;

//        public BasePage(WindowsDriver<WindowsElement> driver)
//        {
//            this.driver = driver;
//        }

//    }
//}
