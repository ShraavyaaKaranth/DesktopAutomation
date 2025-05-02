Feature: happyFlow3

A short summary of the feature

@HappyFlowFeature3
Scenario: User selects multiple items and purchases them
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
	When User clicks on Item field
	And User enters "banana" in Search field
	And User clicks on OK button
	Then Matching items are displayed
	When User selects item at position "1" and clicks on OK
	Then Item is added to cart
	When User clicks on Item field
	And User enters "cauliflower" in Search field
	And User clicks on OK button
	Then Matching items are displayed
	When User selects item at position "1" and clicks on OK
	Then Item is added to cart
	When User clicks on enter
	And User enters the amount to be paid and clicks enter
	Then Receipt options will be shown
	When User selects the type of receipt he wants
	Then The receipt will be generated
