Feature: HappyFlow2

A short summary of the feature

@HappyFlowFeature2
Scenario: User tries to return an item online
	Given User is on landing page
	When User selects the Receipt tab and clicks on OK
	And User selects the option to search for a Finished receipt
	And User enters the valid Finished receipt number
	And User clicks on OK
	When User clicks on Online Return button
	And User selects one item for return and clicks on OK
	And User clicks on the Finish button
	And User selects the reason for return
	Then The user is navigated to the Sales Board
	When User clicks Enter button
	And User enters the amount and clicks on the OK button
	And User selects the payment type and clicks on it
	And User selects the receipt type and clicks on it
	Then The receipt should be generated successfully
