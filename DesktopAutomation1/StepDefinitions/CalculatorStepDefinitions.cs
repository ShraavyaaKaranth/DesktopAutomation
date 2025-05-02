using NUnit.Framework;
using TechTalk.SpecFlow;
using DesktopAutomation1.Pages;
using DesktopAutomation1.Drivers;

namespace DesktopAutomation1.StepDefinitions
{
    [Binding]
    public class CalculatorSteps
    {
        private readonly CalculatorPage calculatorPage = new();

        [Given(@"the calculator is open")]
        public void GivenTheCalculatorIsOpen()
        {
            // Driver is already started in BasePage
            Console.WriteLine("calculator open");
        }

        [When(@"I add (.*) and (.*)")]
        public void WhenIAddTwoNumbers(int num1, int num2)
        {
            calculatorPage.ClickNumber(num1);
            calculatorPage.ClickPlus();
            calculatorPage.ClickNumber(num2);
            calculatorPage.ClickEquals();
        }

        [Then(@"the result should be (.*)")]
        public void ThenTheResultShouldBe(int expectedResult)
        {
            string result = calculatorPage.GetResult();
            Assert.AreEqual(expectedResult.ToString(), result);
            //Console.WriteLine($"{expectedResult}");
            //WinAppDriverManager.StopSession();
        }
    }
}
