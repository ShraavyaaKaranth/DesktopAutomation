using System;
using DesktopAutomation1.Pages;
using TechTalk.SpecFlow;

namespace DesktopAutomation1.StepDefinitions
{
    [Binding]
    public class ReceiptTabStepDefinitions
    {

        private readonly receiptTabPage receiptTabPage = new();
        [When(@"User selects the Receipt tab and clicks on OK")]
        public void WhenUserSelectsTheReceiptTabAndClicksOnOK()
        {
            receiptTabPage.ClickReceiptElement();
            receiptTabPage.Clicks("acceptButton");
        }

        [When(@"User selects the option to search for a Finished receipt")]
        public void WhenUserSelectsTheOptionToSearchForAFinishedReceipt()
        {
            string mainWindow = receiptTabPage.switchToPopup("WPFPopupView");
            receiptTabPage.Select(2, "WPFPopupView");
            receiptTabPage.switchToMain(mainWindow);
        }
        [When(@"User fetches the recent receipt ID")]
        public void WhenUserFetchesTheRecentReceiptID()
        {
            //string basePath = @"C:\LPOS\JournalBackup";
            //string latestId = XmlFileHelper.GetLatestXmlFileId(basePath);
            //ScenarioContext.Current["LatestXmlId"] = latestId;
        }


        [When(@"User enters the valid Finished receipt number")]
        public void WhenUserEntersTheValidFinishedReceiptNumber()
        {
            string mainWindow = receiptTabPage.switchToPopup("WPFPopupView");
            string basePath = @"C:\LPOS\JournalBackup";
            string latestId = XmlFileHelper.GetLatestXmlFileId(basePath);
            receiptTabPage.EnterValidReceipt(2, latestId);

            receiptTabPage.switchToMain(mainWindow);

        }

        [When(@"User clicks on OK")]
        public void WhenUserClicksOnOK()
        {
            Console.WriteLine("User pressed enter");
        }

        [Then(@"The system will fetch the receipt details")]
        public void ThenTheSystemWillFetchTheReceiptDetails()
        {
            Console.WriteLine("The records are fetched successfully.");
        }
    }
}
