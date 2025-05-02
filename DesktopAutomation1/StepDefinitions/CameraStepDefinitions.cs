//using System;
//using DesktopAutomation1.Drivers;
//using DesktopAutomation1.Pages;
//using TechTalk.SpecFlow;

//namespace DesktopAutomation1.StepDefinitions
//{
//    [Binding]
//    public class CameraStepDefinitions
//    {
//        private readonly CameraPage cameraPage = new();
//        [Given(@"camera is open")]
//        public void GivenCameraIsOpen()
//        {
//            Console.WriteLine("camera is open");
//        }

//        [When(@"uesr clicks on shutter button")]
//        public void WhenUesrClicksOnShutterButton()
//        {
//            cameraPage.Toggle();
//            //cameraPage.Toggle();
//            cameraPage.Capture();
//        }

//        [Then(@"image ic captured")]
//        public void ThenImageIcCaptured()
//        {
//            Console.WriteLine("image captured");
//            WinAppDriverManager.StopSession();
//        }
//    }
//}
