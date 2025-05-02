using System;
using DesktopAutomation1.Pages;
using TechTalk.SpecFlow;

namespace DesktopAutomation1.StepDefinitions
{
    [Binding]
    public class TeamsAutomationStepDefinitions
    {
        private readonly teamsPage teamsPage = new();
        [Given(@"User has opened teams application")]
        public void GivenUserHasOpenedTeamsApplication()
        {
            //Thread.Sleep(3000);
            Console.WriteLine("Teams is open");
        }

        [When(@"User click on ""([^""]*)""")]
        public void WhenUserClicksOn(string button)
        {
            Thread.Sleep(3000);
            teamsPage.ClickButton(button);
        }

        [Then(@"The link is opened in a browser")]
        public void ThenTheLinkIsOpenedInABrowser()
        {
            Thread.Sleep(3000);
            Console.WriteLine("opened");
        }
    }
}
