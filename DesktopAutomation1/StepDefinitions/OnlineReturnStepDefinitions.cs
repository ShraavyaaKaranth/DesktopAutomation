using System;
using DesktopAutomation1.Pages;
using TechTalk.SpecFlow;

namespace DesktopAutomation1.StepDefinitions
{
    [Binding]
    public class OnlineReturnStepDefinitions
    {
        private readonly onlineReturnPage onlineReturnPage = new();

        [Given(@"User is on the landing page and the system has the recipt details")]
        public void GivenUserIsOnTheLandingPageAndTheSystemHasTheReciptDetails()
        {
            Console.WriteLine("The system has fetched the receipt details");
        }

        [When(@"User clicks on Online Return button")]
        public void WhenUserClicksOnOnlineReturnButton()
        {
            onlineReturnPage.ClicksButton();
        }

        [When(@"User selects one item for return and clicks on OK")]
        public void WhenUserSelectsOneItemForReturnAndClicksOnOK()
        {
            onlineReturnPage.adding(0);
        }

        [When(@"User clicks on the Finish button")]
        public void WhenUserClicksOnTheFinishButton()
        {
            onlineReturnPage.ClicksButton();
        }

        [When(@"User selects the reason for return")]
        public void WhenUserSelectsTheReasonForReturn()
        {
            string mainWindow = onlineReturnPage.switchToPopup("WPFPopupView");
            onlineReturnPage.Select(2, "WPFPopupView");
            onlineReturnPage.switchToMain(mainWindow);
        }

        [Then(@"The user is navigated to the Sales Board")]
        public void ThenTheUserIsNavigatedToTheSalesBoard()
        {
            Console.WriteLine("User is navigated to sales board");
        }
    }
}
