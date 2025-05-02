Feature: addToCart

A short summary of the feature

@addToCart
Scenario:User adds an item to cart
	Given User is on a page where matching items are displayed
	When User selects an item and clicks on OK
	Then Item is added to cart
