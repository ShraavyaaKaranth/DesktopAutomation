using System;
using DesktopAutomation1.Pages;
using TechTalk.SpecFlow;

namespace DesktopAutomation1.StepDefinitions
{
    [Binding]
    public class PaymentStepDefinitions
    {
        private readonly paymentPage paymentPage = new();
        private readonly popupHandler popupHandler = new();
        [Given(@"User has added the item to the cart")]
        public void GivenUserHasAddedTheItemToTheCart()
        {
            Console.WriteLine("Items in cart are shown");
        }

        [When(@"User clicks on enter")]
        public void WhenUserClicksOnEnter()
        {
            Thread.Sleep(1500);
            paymentPage.Clicks("InputField");
        }

        [When(@"User enters the amount to be paid and clicks enter")]
        public void WhenUserEntersTheAmountToBePaidAndClicksEnter()
        {
            paymentPage.Send();
        }

        [Then(@"Receipt options will be shown")]
        public void ThenReceiptOptionsWillBeShown()
        {
            popupHandler.acceptPopup("Button", "BtnYes");
        }
    }
}
