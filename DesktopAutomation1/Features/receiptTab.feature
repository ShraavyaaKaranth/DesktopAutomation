Feature: receiptTab

A short summary of the feature

@receiptTab
Scenario: User tries fetch the receipt details
	Given User is on landing page
	When User selects the Receipt tab and clicks on OK
	And User selects the option to search for a Finished receipt
	And User fetches the recent receipt ID
	And User enters the valid Finished receipt number
	And User clicks on OK
	Then The system will fetch the receipt details
