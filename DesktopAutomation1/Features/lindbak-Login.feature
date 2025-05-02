Feature: lindbak

A short summary of the feature

@login
Scenario: User is logging into the application
	Given User has loaded the application
	When User enters username
	And User enters password
	And User clicks on login button
	Then User is logged in
