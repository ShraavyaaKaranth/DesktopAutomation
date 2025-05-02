using System;
using DesktopAutomation1.Pages;
using TechTalk.SpecFlow;

namespace DesktopAutomation1.StepDefinitions
{
    [Binding]
    public class AddToCartStepDefinitions
    {
        private readonly addToCartPage addToCartPage = new();
        [Given(@"User is on a page where matching items are displayed")]
        public void GivenUserIsOnAPageWhereMatchingItemsAreDisplayed()
        {
            Console.WriteLine("Items are displayed");
        }

        [When(@"User selects item at position ""([^""]*)"" and clicks on OK")]
        public void WhenUserSelectsItemAtPositionAndClicksOnOK(string num)
        {
            addToCartPage.adding(num);
            addToCartPage.clickButton("acceptButton");
            Thread.Sleep(1500);
        }


        [Then(@"Item is added to cart")]
        public void ThenItemIsAddedToCart()
        {
            Console.WriteLine("Item added to cart.");
        }
    }
}
