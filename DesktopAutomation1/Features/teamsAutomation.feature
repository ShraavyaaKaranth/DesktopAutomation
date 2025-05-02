Feature: teamsAutomation

A short summary of the feature

@teams
Scenario: User wants to click a link in teams application and open it in a browser
	Given User has opened teams application
	When User click on "Chat"
	And User click on "Chat. Shravya Karanth"
	And User click on "Untitled.pdf"
	Then The link is opened in a browser
