using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesktopAutomation1.Pages;

namespace DesktopAutomation1.StepDefinitions
{
    [Binding]
    public class CommonStepDefinitions
    {
        private readonly commonPage commonPage = new();
        private readonly popupHandler popupHandler = new();
        [When(@"User enters ""([^""]*)"" in ""([^""]*)"" field")]
        public void WhenUserEntersInField(string value, string fieldname)
        {
            Thread.Sleep(3000);

            commonPage.Send(value, fieldname);
            //loginPage.Send(value, "passwordTextbox");

        }

        [When(@"User clicks on ""([^""]*)"" item at field ""([^""]*)""")]
        public void WhenUserClicksOnItemAtField(string Buttonitem, string p1)
        {
            //Thread.Sleep(3000);
            //commonPage.ClickClassItem(Buttonitem, p1);
            //loginPage.Clicks();
        }
    }
}
