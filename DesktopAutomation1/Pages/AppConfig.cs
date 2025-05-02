namespace DesktopAutomation1.Config
{
    public static class AppConfig
    {
        public static bool UseRemote = false;

        public static string RemoteIP = "10.163.226.101:4724"; // Remote WinAppDriver URI

        public static string LocalAppPath = @"C:\Users\shkar\Desktop\testExec\Automation\Lindbak POS.exe";
        public static string RemoteAppPath = @"C:\Users\PosUser\Desktop\shravya\Automation\Lindbak POS.exe";

        public static string AppPath => UseRemote ? RemoteAppPath : LocalAppPath;
    }

}
