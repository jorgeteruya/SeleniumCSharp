Feature: CheckOut

A short summary of the feature

@tag1
Scenario Outline: CheckOut
	Given I login on sauce labs with user "standard_user"
	When I select a product
	Then go to checkout page and complete the fields
		| FirstName | LastName | ZipCode  |
		| Jorge     | Teruya   | 03277110 |
	

Examples:
	| user          | password        |
	| standard_user | secret_sauce*01 |
	| standard_user | secret_sauce*01 |
