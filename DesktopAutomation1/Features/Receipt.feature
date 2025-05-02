Feature: Receipt

A short summary of the feature

@receipt
Scenario: User chooses the type of receipt he wants
	Given User is on Digital Receipt page
	When User selects the type of receipt he wants
	Then The receipt will be generated
