Feature: CheckOut

A short summary of the feature

@ChechOut
Scenario Outline: CheckOut
	Given I login on sauce labs with user "standard_user"
	When I select a <Product>
		| Product    |
		| flashlight |
		| Backpack   |
	Then go to checkout page and complete the fields below
		| FirstName | LastName | ZipCode |
		| Test      | Tester   | 123456  |
		| Test2     | Tester   | 123456  |

	
Examples:
	| user          | password        |
	| standard_user | secret_sauce*01 |

