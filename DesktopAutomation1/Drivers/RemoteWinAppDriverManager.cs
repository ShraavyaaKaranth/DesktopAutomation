using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;
using System;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using DesktopAutomation1.Config;

namespace DesktopAutomation1.Drivers
{
    public class RemoteWinAppDriverManager
    {
        private static WindowsDriver<WindowsElement> driver;

        [DllImport("user32.dll")]
        private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        [DllImport("user32.dll")]
        private static extern bool SetForegroundWindow(IntPtr hWnd);

        private const int SW_RESTORE = 9;

        public static WindowsDriver<WindowsElement> GetDriver()
        {
            if (driver == null)
            {
                Console.WriteLine("Initializing remote WinAppDriver session through relay...");

                var options = new AppiumOptions();
                options.AddAdditionalCapability("app", AppConfig.AppPath);
                options.AddAdditionalCapability("deviceName", "WindowsPC");
                options.AddAdditionalCapability("platformName", "Windows");

                // Updated to use local relay instead of remote IP
                driver = new WindowsDriver<WindowsElement>(
                    new Uri($"http://{AppConfig.RemoteIP}"), options);
                


                Console.WriteLine("Connected to remote WinAppDriver through relay.");
            }

            return driver;
        }

        private static void RestoreAndFocusWindow(IntPtr mainWindowHandle)
        {
            Console.WriteLine("Bringing remote application to front...");
            ShowWindow(mainWindowHandle, SW_RESTORE);
            SetForegroundWindow(mainWindowHandle);
        }
    }
}
