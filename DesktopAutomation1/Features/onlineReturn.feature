Feature: onlineReturn

A short summary of the feature

@onlineReturn
Scenario: User returns an item
	Given User is on the landing page and the system has the recipt details
	When User clicks on Online Return button
	And User selects one item for return and clicks on OK
	And User clicks on the Finish button
	And User selects the reason for return
	Then The user is navigated to the Sales Board
