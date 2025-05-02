Feature: payment

A short summary of the feature

@payment
Scenario: The user goes to payment transaction page
	Given User has added the item to the cart
	When User clicks on enter
	And User enters the amount to be paid and clicks enter
	Then Receipt options will be shown
