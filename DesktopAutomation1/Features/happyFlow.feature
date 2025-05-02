Feature: HappyFlow1

A short summary of the feature

@happyFlow
Scenario: User logs in, selects and item and buys it
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
