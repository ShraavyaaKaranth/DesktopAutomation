using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using DesktopAutomation1.Config;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;

public static class WinAppDriverManager
{
    public static WindowsDriver<WindowsElement> driver;

    [DllImport("user32.dll")]
    private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

    [DllImport("user32.dll")]
    private static extern bool SetForegroundWindow(IntPtr hWnd);

    private const int SW_RESTORE = 9;

    private static void StartWinAppDriverIfNotRunning()
    {
        var processes = Process.GetProcessesByName("WinAppDriver");
        if (processes.Length == 0)
        {
            Process.Start(new ProcessStartInfo
            {
                FileName = @"C:\Program Files (x86)\Windows Application Driver\WinAppDriver.exe",
                UseShellExecute = true
            });
            Thread.Sleep(3000); // Give it time to start
        }
    }

    public static void StartSession(string appPath)
    {
        if (driver != null)
        {
            Console.WriteLine("Driver is already initialized.");
            return;
        }

        if (AppConfig.UseRemote)
        {
            StartRemoteSession(AppConfig.RemoteAppPath);
            return;
        }
        //if (!AppConfig.UseRemote)
        //{
        //    StartWinAppDriverIfNotRunning(); // Add this
        //}
        IntPtr mainWindowHandle = GetRunningApplicationWindow(appPath);

        if (mainWindowHandle == IntPtr.Zero)
        {
            Console.WriteLine("Application is not running. Launching...");
            Process process = Process.Start(appPath);

            if (process == null)
                throw new Exception("Failed to start application process.");

            int processId = process.Id;
            Console.WriteLine($"Started application with Process ID: {processId}");

            mainWindowHandle = WaitForMainWindow(processId);

            if (mainWindowHandle == IntPtr.Zero)
                throw new Exception("Application window did not appear in time.");
        }
        else
        {
            Console.WriteLine("Application is already running. Attaching to existing window...");
        }

        RestoreAndFocusWindow(mainWindowHandle);
        AttachToLocalApplication(mainWindowHandle);
    }

    private static void StartRemoteSession(string appPath)
    {
        var options = new AppiumOptions();
        options.AddAdditionalCapability("app", appPath);
        options.AddAdditionalCapability("deviceName", "WindowsPC");
        options.AddAdditionalCapability("platformName", "Windows");

        driver = new WindowsDriver<WindowsElement>(
            new Uri($"http://{AppConfig.RemoteIP}"), options);

        Console.WriteLine("Launched application on remote machine.");
    }

    private static void AttachToLocalApplication(IntPtr windowHandle)
    {
        var options = new AppiumOptions();
        options.AddAdditionalCapability("appTopLevelWindow", windowHandle.ToInt64().ToString("X"));
        options.AddAdditionalCapability("deviceName", "WindowsPC");
        options.AddAdditionalCapability("platformName", "Windows");

        driver = new WindowsDriver<WindowsElement>(
            new Uri("http://127.0.0.1:4723"), options);

        Console.WriteLine("Attached to local application.");
    }

    private static void RestoreAndFocusWindow(IntPtr hWnd)
    {
        ShowWindow(hWnd, SW_RESTORE);
        SetForegroundWindow(hWnd);
    }

    private static IntPtr WaitForMainWindow(int processId, int timeoutSeconds = 15)
    {
        var stopwatch = Stopwatch.StartNew();
        while (stopwatch.Elapsed.TotalSeconds < timeoutSeconds)
        {
            var process = Process.GetProcessById(processId);
            if (process.MainWindowHandle != IntPtr.Zero)
                return process.MainWindowHandle;
            System.Threading.Thread.Sleep(500);
        }
        return IntPtr.Zero;
    }

    private static IntPtr GetRunningApplicationWindow(string processPath)
    {
        string processName = System.IO.Path.GetFileNameWithoutExtension(processPath);
        var processes = Process.GetProcessesByName(processName);

        foreach (var process in processes)
        {
            if (process.MainWindowHandle != IntPtr.Zero)
                return process.MainWindowHandle;
        }
        return IntPtr.Zero;
    }

    public static void CloseSession()
    {
        if (driver != null)
        {
            driver.Quit();
            driver = null;
        }
    }
    public static WindowsDriver<WindowsElement> GetDriver()
    {
        return driver;
    }

}


















//using OpenQA.Selenium.Appium;
//using OpenQA.Selenium.Appium.Windows;
//using System;
//using System.Diagnostics;
//using System.Linq;
//using System.Runtime.InteropServices;
//using System.Threading;
//using DesktopAutomation1.Config;

//namespace DesktopAutomation1.Drivers
//{
//    public class WinAppDriverManager
//    {
//        private static WindowsDriver<WindowsElement> driver;

//        [DllImport("user32.dll")]
//        private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

//        [DllImport("user32.dll")]
//        private static extern bool SetForegroundWindow(IntPtr hWnd);

//        private const int SW_RESTORE = 9;

//        public static void StartSession(string appPath)
//        {
//            if (AppConfig.UseRemote)
//            {
//                RemoteWinAppDriverManager.GetDriver();
//                return;
//            }

//            if (driver != null)
//            {
//                Console.WriteLine("Driver is already initialized.");
//                return;
//            }

//            IntPtr mainWindowHandle = GetRunningApplicationWindow(appPath);

//            if (mainWindowHandle == IntPtr.Zero)
//            {
//                Console.WriteLine("Application is not running. Launching...");
//                Process process = Process.Start(appPath);

//                if (process == null)
//                {
//                    throw new Exception("Failed to start application process.");
//                }

//                int processId = process.Id;
//                Console.WriteLine($"Started application with Process ID: {processId}");

//                mainWindowHandle = WaitForMainWindow(processId);

//                if (mainWindowHandle == IntPtr.Zero)
//                {
//                    throw new Exception("Application window did not appear in time.");
//                }
//            }
//            else
//            {
//                Console.WriteLine("Application is already running. Attaching to existing window...");
//            }

//            RestoreAndFocusWindow(mainWindowHandle);
//            AttachToApplication(mainWindowHandle);
//        }

//        public static WindowsDriver<WindowsElement> GetDriver()
//        {
//            if (AppConfig.UseRemote)
//                return RemoteWinAppDriverManager.GetDriver();

//            if (driver == null)
//            {
//                Console.WriteLine("Driver is not initialized. Checking if application is running...");

//                IntPtr mainWindowHandle = GetRunningApplicationWindow(AppConfig.AppPath);

//                if (mainWindowHandle == IntPtr.Zero)
//                {
//                    throw new InvalidOperationException("Application is not open. Please start the application manually.");
//                }

//                Console.WriteLine("Attaching to the already open application...");
//                RestoreAndFocusWindow(mainWindowHandle);
//                AttachToApplication(mainWindowHandle);
//            }
//            return driver;
//        }

//        private static void AttachToApplication(IntPtr mainWindowHandle)
//        {
//            var options = new AppiumOptions();
//            options.AddAdditionalCapability("platformName", "Windows");
//            options.AddAdditionalCapability("deviceName", "WindowsPC");
//            options.AddAdditionalCapability("appTopLevelWindow", mainWindowHandle.ToInt64().ToString("X"));

//            driver = new WindowsDriver<WindowsElement>(new Uri($"http://{AppConfig.RemoteIP}"), options);
//            Console.WriteLine("Successfully attached to application window.");
//        }

//        private static IntPtr GetRunningApplicationWindow(string appPath)
//        {
//            string processName = System.IO.Path.GetFileNameWithoutExtension(appPath);
//            var processes = Process.GetProcessesByName(processName);

//            foreach (var process in processes)
//            {
//                if (process.MainWindowHandle != IntPtr.Zero)
//                {
//                    return process.MainWindowHandle;
//                }
//            }

//            return IntPtr.Zero;
//        }

//        private static IntPtr WaitForMainWindow(int processId)
//        {
//            IntPtr mainWindowHandle = IntPtr.Zero;
//            int retries = 20;

//            while (retries > 0 && mainWindowHandle == IntPtr.Zero)
//            {
//                var process = Process.GetProcessById(processId);
//                process.Refresh();
//                mainWindowHandle = process.MainWindowHandle;

//                if (mainWindowHandle == IntPtr.Zero)
//                {
//                    Console.WriteLine("Waiting for application window...");
//                    Thread.Sleep(1000);
//                    retries--;
//                }
//            }
//            return mainWindowHandle;
//        }

//        private static void RestoreAndFocusWindow(IntPtr mainWindowHandle)
//        {
//            Console.WriteLine("Bringing application to the front...");
//            ShowWindow(mainWindowHandle, SW_RESTORE);
//            SetForegroundWindow(mainWindowHandle);
//        }
//    }
//}











//using OpenQA.Selenium.Appium;
//using OpenQA.Selenium.Appium.Windows;
//using System;
//using System.Diagnostics;
//using System.Linq;
//using System.Runtime.InteropServices;
//using System.Threading;

//namespace DesktopAutomation1.Drivers
//{
//    public class WinAppDriverManager
//    {
//        private static WindowsDriver<WindowsElement> driver;

//        [DllImport("user32.dll")]
//        private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

//        [DllImport("user32.dll")]
//        private static extern bool SetForegroundWindow(IntPtr hWnd);

//        private const int SW_RESTORE = 9;

//        public static void StartSession(string appPath)
//        {
//            if (driver != null)
//            {
//                Console.WriteLine("Driver is already initialized.");
//                return;
//            }

//            IntPtr mainWindowHandle = GetRunningApplicationWindow(appPath);

//            if (mainWindowHandle == IntPtr.Zero)
//            {
//                Console.WriteLine("Application is not running. Launching...");
//                Process process = Process.Start(appPath);

//                if (process == null)
//                {
//                    throw new Exception("Failed to start application process.");
//                }

//                int processId = process.Id;
//                Console.WriteLine($"Started application with Process ID: {processId}");

//                mainWindowHandle = WaitForMainWindow(processId);

//                if (mainWindowHandle == IntPtr.Zero)
//                {
//                    throw new Exception("Application window did not appear in time.");
//                }
//            }
//            else
//            {
//                Console.WriteLine("Application is already running. Attaching to existing window...");
//            }

//            RestoreAndFocusWindow(mainWindowHandle);
//            AttachToApplication(mainWindowHandle);
//        }

//        public static WindowsDriver<WindowsElement> GetDriver()
//        {
//            if (driver == null)
//            {
//                Console.WriteLine("Driver is not initialized. Checking if application is running...");

//                IntPtr mainWindowHandle = GetRunningApplicationWindow(@"C:\Users\shkar\Desktop\testExec\Automation\Lindbak POS.exe");

//                if (mainWindowHandle == IntPtr.Zero)
//                {
//                    throw new InvalidOperationException("Application is not open. Please start the application manually.");
//                }

//                Console.WriteLine("Attaching to the already open application...");
//                RestoreAndFocusWindow(mainWindowHandle);
//                AttachToApplication(mainWindowHandle);
//            }
//            return driver;
//        }

//        private static void AttachToApplication(IntPtr mainWindowHandle)
//        {
//            var options = new AppiumOptions();
//            options.AddAdditionalCapability("platformName", "Windows");
//            options.AddAdditionalCapability("deviceName", "WindowsPC");
//            options.AddAdditionalCapability("appTopLevelWindow", mainWindowHandle.ToInt64().ToString("X"));

//            driver = new WindowsDriver<WindowsElement>(new Uri("http://127.0.0.1:4723"), options);
//            Console.WriteLine("Successfully attached to application window.");
//        }

//        private static IntPtr GetRunningApplicationWindow(string appPath)
//        {
//            string processName = System.IO.Path.GetFileNameWithoutExtension(appPath);
//            var processes = Process.GetProcessesByName(processName);

//            foreach (var process in processes)
//            {
//                if (process.MainWindowHandle != IntPtr.Zero)
//                {
//                    return process.MainWindowHandle;
//                }
//            }

//            return IntPtr.Zero;
//        }

//        private static IntPtr WaitForMainWindow(int processId)
//        {
//            IntPtr mainWindowHandle = IntPtr.Zero;
//            int retries = 20;

//            while (retries > 0 && mainWindowHandle == IntPtr.Zero)
//            {
//                var process = Process.GetProcessById(processId);
//                process.Refresh();
//                mainWindowHandle = process.MainWindowHandle;

//                if (mainWindowHandle == IntPtr.Zero)
//                {
//                    Console.WriteLine("Waiting for application window...");
//                    Thread.Sleep(1000);
//                    retries--;
//                }
//            }
//            return mainWindowHandle;
//        }

//        private static void RestoreAndFocusWindow(IntPtr mainWindowHandle)
//        {
//            Console.WriteLine("Bringing application to the front...");
//            ShowWindow(mainWindowHandle, SW_RESTORE);
//            SetForegroundWindow(mainWindowHandle);
//        }
//    }
//}





















////using OpenQA.Selenium.Appium.Windows;
////using System;
////using System.Diagnostics;
////using System.Runtime.InteropServices;
////using System.Threading;
////using DesktopAutomation1.Config;
////using OpenQA.Selenium.Appium; // Import the Config namespace

////namespace DesktopAutomation1.Drivers
////{
////    public class WinAppDriverManager
////    {
////        private static WindowsDriver<WindowsElement> driver;
////        private static string remoteIp = AppConfig.RemoteIP;
////        private static string appPath = AppConfig.AppPath;

////        [DllImport("user32.dll")]
////        private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

////        [DllImport("user32.dll")]
////        private static extern bool SetForegroundWindow(IntPtr hWnd);

////        private const int SW_RESTORE = 9;

////        public static void StartRemoteSession()
////        {
////            string remoteIP = AppConfig.RemoteIP; // Example: 10.163.226.101
////            string appPath = AppConfig.AppPath;

////            var appOptions = new AppiumOptions();
////            appOptions.AddAdditionalCapability("app", appPath); // WinAppDriver will launch the app
////            appOptions.AddAdditionalCapability("platformName", "Windows");
////            appOptions.AddAdditionalCapability("deviceName", "WindowsPC");

////            Uri winAppDriverUrl = new Uri($"http://{remoteIP}:4723/wd/hub");
////            driver = new WindowsDriver<WindowsElement>(winAppDriverUrl, appOptions, TimeSpan.FromSeconds(180));
////        }



////        public static WindowsDriver<WindowsElement> GetDriver()
////        {
////            if (driver == null)
////                throw new InvalidOperationException("Driver is not initialized. Call StartRemoteSession first.");
////            return driver;
////        }


////        private static void AttachToApplication(string remoteIp, IntPtr mainWindowHandle)
////        {
////            var options = new AppiumOptions();
////            options.AddAdditionalCapability("platformName", "Windows");
////            options.AddAdditionalCapability("deviceName", "WindowsPC");
////            options.AddAdditionalCapability("appTopLevelWindow", mainWindowHandle.ToInt64().ToString("X"));

////            driver = new WindowsDriver<WindowsElement>(new Uri($"http://{remoteIp}:4723"), options);
////            Console.WriteLine("Successfully attached to application window.");
////        }

////        private static IntPtr GetRunningApplicationWindow(string appPath)
////        {
////            string processName = System.IO.Path.GetFileNameWithoutExtension(appPath);
////            var processes = Process.GetProcessesByName(processName);

////            foreach (var process in processes)
////            {
////                if (process.MainWindowHandle != IntPtr.Zero)
////                {
////                    return process.MainWindowHandle;
////                }
////            }

////            return IntPtr.Zero;
////        }

////        private static IntPtr WaitForMainWindow(int processId)
////        {
////            IntPtr mainWindowHandle = IntPtr.Zero;
////            int retries = 20;

////            while (retries > 0 && mainWindowHandle == IntPtr.Zero)
////            {
////                var process = Process.GetProcessById(processId);
////                process.Refresh();
////                mainWindowHandle = process.MainWindowHandle;

////                if (mainWindowHandle == IntPtr.Zero)
////                {
////                    Console.WriteLine("Waiting for application window...");
////                    Thread.Sleep(1000);
////                    retries--;
////                }
////            }
////            return mainWindowHandle;
////        }

////        private static void RestoreAndFocusWindow(IntPtr mainWindowHandle)
////        {
////            Console.WriteLine("Bringing application to the front...");
////            ShowWindow(mainWindowHandle, SW_RESTORE);
////            SetForegroundWindow(mainWindowHandle);
////        }
////    }
////}
