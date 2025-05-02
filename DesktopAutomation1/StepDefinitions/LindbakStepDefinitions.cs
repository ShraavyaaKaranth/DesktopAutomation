
using System;
using DesktopAutomation1.Pages;
using DesktopAutomation1.Drivers;
using TechTalk.SpecFlow;
using DesktopAutomation1.Config;

namespace DesktopAutomation1.StepDefinitions
{
    [Binding]
    public class LindbakStepDefinitions
    {
        private string appPath;
        private loginPage loginPage;
        private viewItemPage viewItemPage;
        private readonly popupHandler popupHandler;

        public LindbakStepDefinitions()
        {
            appPath = AppConfig.AppPath;

            WinAppDriverManager.StartSession(appPath);

            loginPage = new loginPage();
            viewItemPage = new viewItemPage();
            popupHandler = new popupHandler();
        }

        [Given(@"User has loaded the application")]
        public void GivenUserHasLoadedTheApplication()
        {
            Console.WriteLine("User is on login page.");
        }

        [When(@"User enters username")]
        public void WhenUserEntersUsername()
        {
            Thread.Sleep(10000);
            loginPage.Send("admin", "userNameTextbox");
        }

        [When(@"User enters password")]
        public void WhenUserEntersPassword()
        {
            loginPage.Send("admin", "passwordTextbox");
        }

        [When(@"User clicks on login button")]
        public void WhenUserClicksOnLoginButton()
        {
            loginPage.Clicks("Button");
            Thread.Sleep(3000);
        }

        [Then(@"User is logged in")]
        public void ThenUserIsLoggedIn()
        {
            Thread.Sleep(3000);
            popupHandler.acceptPopup("WPFPopupView", "BtnOK");
            Console.WriteLine("User is logged in.");
        }
    }
}


//using System;
//using DesktopAutomation1.Pages;
//using DesktopAutomation1.Drivers;
//using TechTalk.SpecFlow;

//namespace DesktopAutomation1.StepDefinitions
//{
//    [Binding]
//    public class LindbakStepDefinitions
//    {
//        private string appPath;
//        private loginPage loginPage;
//        private viewItemPage viewItemPage;
//        private readonly popupHandler popupHandler;

//        public LindbakStepDefinitions()
//        {
//            WinAppDriverManager.StartRemoteSession();  // Reads IP and path from AppConfig

//            loginPage = new loginPage();       // No changes needed here
//            viewItemPage = new viewItemPage();
//            popupHandler = new popupHandler();
//        }
//        //public LindbakStepDefinitions()
//        //{
//        //    appPath = @"C:\Users\shkar\Desktop\testExec\Automation\Lindbak POS.exe";

//        //    LocalWinAppDriverManager.StartSession(appPath);

//        //    loginPage = new loginPage();
//        //    viewItemPage = new viewItemPage();
//        //    popupHandler = new popupHandler();
//        //}

//        [Given(@"User has loaded the application")]
//        public void GivenUserHasLoadedTheApplication()
//        {
//            Console.WriteLine("User is on login page.");
//        }

//        [When(@"User enters username")]
//        public void WhenUserEntersUsername()
//        {
//            loginPage.Send("admin", "userNameTextbox");
//        }

//        [When(@"User enters password")]
//        public void WhenUserEntersPassword()
//        {
//            loginPage.Send("admin", "passwordTextbox");
//        }

//        [When(@"User clicks on login button")]
//        public void WhenUserClicksOnLoginButton()
//        {
//            loginPage.Clicks("Button");
//            Thread.Sleep(3000);
//        }

//        [Then(@"User is logged in")]
//        public void ThenUserIsLoggedIn()
//        {
//            Thread.Sleep(3000);
//            popupHandler.acceptPopup("WPFPopupView", "BtnOK");
//            Console.WriteLine("User is logged in.");
//        }
//    }
//}


