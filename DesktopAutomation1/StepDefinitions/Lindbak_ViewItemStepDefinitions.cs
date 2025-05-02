using System;
using DesktopAutomation1.Pages;
using TechTalk.SpecFlow;

namespace DesktopAutomation1.StepDefinitions
{
    [Binding]
    public class Lindbak_ViewItemStepDefinitions
    {
        private readonly viewItemPage viewItemPage;
        private string parentclass;

        public Lindbak_ViewItemStepDefinitions()
        {
            viewItemPage = new viewItemPage();
        }

        [Given(@"User is on landing page")]
        public void GivenUserIsOnLandingPage()
        {
            Console.WriteLine("User is on the landing page.");
        }

        [When(@"User clicks on ""([^""]*)""")]
        public void WhenUserClicksOn(string expandedSelectSearchView)
        {
            parentclass = expandedSelectSearchView;
        }

        [When(@"User clicks on Item field")]
        public void WhenUserClicksOnItemField()
        {
            viewItemPage.ClickViewElement();
            Console.Write("View is clicked.");
        }

        [When(@"User enters ""([^""]*)"" in Search field")]
        public void WhenUserEntersInSearchField(string itemName)
        {
            viewItemPage.Send(itemName, "SearchBox_Empty");
        }


        [When(@"User clicks on OK button")]
        public void WhenUserClicksOnOKButton()
        {
            viewItemPage.clickButton("acceptButton");
        }

        [Then(@"Matching items are displayed")]
        public void ThenMatchingItemsAreDisplayed()
        {
            Console.WriteLine("Matching items are displayed.");
        }
    }
}
