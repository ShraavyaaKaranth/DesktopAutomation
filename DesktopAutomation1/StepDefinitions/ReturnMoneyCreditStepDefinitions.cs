using System;
using DesktopAutomation1.Pages;
using TechTalk.SpecFlow;

namespace DesktopAutomation1.StepDefinitions
{
    [Binding]
    public class ReturnMoneyCreditStepDefinitions
    {
        private readonly returnMoneyCreditPage returnMoneyCreditPage = new();
        private readonly popupHandler popupHandler = new();
        private readonly receiptPage receiptPage = new();


        [Given(@"User is on the Sales Board")]
        public void GivenUserIsOnTheSalesBoard()
        {
            Console.WriteLine("User is on sales board");
        }

        [When(@"User clicks Enter button")]
        public void WhenUserClicksEnterButton()
        {
            returnMoneyCreditPage.Send("InputField");
        }


        [When(@"User enters the amount and clicks on the OK button")]
        public void WhenUserEntersTheAmountAndClicksOnTheOKButton()
        {
            returnMoneyCreditPage.enterPrice();
            popupHandler.acceptPopup("WPFPopupView", "BtnYes");
        }

        [When(@"User selects the payment type and clicks on it")]
        public void WhenUserSelectsThePaymentTypeAndClicksOnIt()
        {
            string mainWindow = returnMoneyCreditPage.switchToPopup("WPFPopupView");
            returnMoneyCreditPage.Select(2, "WPFPopupView");
            Thread.Sleep(4000);
            returnMoneyCreditPage.clickingButton();
            returnMoneyCreditPage.switchToMain(mainWindow);



        }

        [When(@"User selects the receipt type and clicks on it")]
        public void WhenUserSelectsTheReceiptTypeAndClicksOnIt()
        {
            receiptPage.Clicks(2);
        }

        [Then(@"The receipt should be generated successfully")]
        public void ThenTheReceiptShouldBeGeneratedSuccessfully()
        {
            Console.WriteLine("Receipt should be generated successfully.");
        }
    }
}
