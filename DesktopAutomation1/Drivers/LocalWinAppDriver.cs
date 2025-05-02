using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;
using System;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;

namespace DesktopAutomation1.Drivers
{
    public class LocalWinAppDriverManager
    {
        private static WindowsDriver<WindowsElement> driver;

        [DllImport("user32.dll")]
        private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        [DllImport("user32.dll")]
        private static extern bool SetForegroundWindow(IntPtr hWnd);

        private const int SW_RESTORE = 9;

        public static void StartSession(string appPath)
        {
            if (driver != null)
            {
                Console.WriteLine("Driver is already initialized.");
                return;
            }

            IntPtr mainWindowHandle = GetRunningApplicationWindow(appPath);

            if (mainWindowHandle == IntPtr.Zero)
            {
                Console.WriteLine("Application is not running. Launching...");
                Process process = Process.Start(appPath);

                if (process == null)
                {
                    throw new Exception("Failed to start application process.");
                }

                int processId = process.Id;
                Console.WriteLine($"Started application with Process ID: {processId}");

                mainWindowHandle = WaitForMainWindow(processId);

                if (mainWindowHandle == IntPtr.Zero)
                {
                    throw new Exception("Application window did not appear in time.");
                }
            }
            else
            {
                Console.WriteLine("Application is already running. Attaching to existing window...");
            }

            RestoreAndFocusWindow(mainWindowHandle);
            AttachToApplication(mainWindowHandle);
        }

        public static WindowsDriver<WindowsElement> GetDriver()
        {
            if (driver == null)
            {
                Console.WriteLine("Driver is not initialized. Checking if application is running...");

                IntPtr mainWindowHandle = GetRunningApplicationWindow(@"C:\Users\shkar\Desktop\testExec\Automation\Lindbak POS.exe");

                if (mainWindowHandle == IntPtr.Zero)
                {
                    throw new InvalidOperationException("Application is not open. Please start the application manually.");
                }

                Console.WriteLine("Attaching to the already open application...");
                RestoreAndFocusWindow(mainWindowHandle);
                AttachToApplication(mainWindowHandle);
            }
            return driver;
        }

        private static void AttachToApplication(IntPtr mainWindowHandle)
        {
            var options = new AppiumOptions();
            options.AddAdditionalCapability("platformName", "Windows");
            options.AddAdditionalCapability("deviceName", "WindowsPC");
            options.AddAdditionalCapability("appTopLevelWindow", mainWindowHandle.ToInt64().ToString("X"));

            driver = new WindowsDriver<WindowsElement>(new Uri("http://127.0.0.1:4723"), options);
            Console.WriteLine("Successfully attached to application window.");
        }

        private static IntPtr GetRunningApplicationWindow(string appPath)
        {
            string processName = System.IO.Path.GetFileNameWithoutExtension(appPath);
            var processes = Process.GetProcessesByName(processName);

            foreach (var process in processes)
            {
                if (process.MainWindowHandle != IntPtr.Zero)
                {
                    return process.MainWindowHandle;
                }
            }

            return IntPtr.Zero;
        }

        private static IntPtr WaitForMainWindow(int processId)
        {
            IntPtr mainWindowHandle = IntPtr.Zero;
            int retries = 20;

            while (retries > 0 && mainWindowHandle == IntPtr.Zero)
            {
                var process = Process.GetProcessById(processId);
                process.Refresh();
                mainWindowHandle = process.MainWindowHandle;

                if (mainWindowHandle == IntPtr.Zero)
                {
                    Console.WriteLine("Waiting for application window...");
                    Thread.Sleep(1000);
                    retries--;
                }
            }
            return mainWindowHandle;
        }

        private static void RestoreAndFocusWindow(IntPtr mainWindowHandle)
        {
            Console.WriteLine("Bringing application to the front...");
            ShowWindow(mainWindowHandle, SW_RESTORE);
            SetForegroundWindow(mainWindowHandle);
        }
    }
}
