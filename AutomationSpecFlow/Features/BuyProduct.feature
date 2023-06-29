Feature: BuyProduct

A short summary of the feature

@tag1
Scenario Outline: Buy a product
	Given I login on sauce labs with user "standard_user"
	When I select the product and add to cart
	Then validate <price> and finish shop

Examples:
	| product | price |
	| test    | 29.00 |
