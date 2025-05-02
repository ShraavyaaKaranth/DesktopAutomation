Feature: returnMoneyCredit

A short summary of the feature

@returnMoneyCredit
Scenario: User returns an item and gets the money credited
	Given User is on the Sales Board
	When User clicks Enter button
	And User enters the amount and clicks on the OK button
	And User selects the payment type and clicks on it
	And User selects the receipt type and clicks on it
	Then The receipt should be generated successfully
