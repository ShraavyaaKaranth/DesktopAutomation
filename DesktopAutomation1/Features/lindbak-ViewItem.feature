Feature: lindbak-ViewItem

A short summary of the feature

@ViewItem
Scenario: User views an item
	Given User is on landing page
	When User clicks on Item field
	And User enters "cherry" in Search field
	And User clicks on OK button
	Then Matching items are displayed
