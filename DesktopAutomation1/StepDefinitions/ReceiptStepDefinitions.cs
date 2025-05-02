using System;
using DesktopAutomation1.Pages;
using TechTalk.SpecFlow;

namespace DesktopAutomation1.StepDefinitions
{
    [Binding]
    public class ReceiptStepDefinitions
    {
        private readonly receiptPage receiptPage = new();

        [Given(@"User is on Digital Receipt page")]
        public void GivenUserIsOnDigitalReceiptPage()
        {
            Console.WriteLine("User is on Digital receipt page");
        }

        [When(@"User selects the type of receipt he wants")]
        public void WhenUserSelectsTheTypeOfReceiptHeWants()
        {
            receiptPage.Clicks(2);
        }

        [Then(@"The receipt will be generated")]
        public void ThenTheReceiptWillBeGenerated()
        {
            Console.Write("receipt generated");
        }
    }
}
