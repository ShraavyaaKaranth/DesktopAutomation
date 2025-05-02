Feature: completeHappyFlow

A short summary of the feature

@completeHappyFlow
Scenario: User logs in, selects and item, buys it and returns one item
	Given User has loaded the application
	When User enters username
	And User enters password
	And User clicks on login button
	Then User is logged in
	When User clicks on Item field
	And User enters "cherry" in Search field
	And User clicks on OK button
	Then Matching items are displayed
	When User selects item at position "2" and clicks on OK
	Then Item is added to cart
	When User clicks on enter
	And User enters the amount to be paid and clicks enter
	Then Receipt options will be shown
	When User selects the type of receipt he wants
	Then The receipt will be generated
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