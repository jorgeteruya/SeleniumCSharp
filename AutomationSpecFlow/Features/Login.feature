Feature: Login SauceLabs

 Validate users and credentials levels

@LoginTest
Scenario Outline: LoginValidation
	Given I access the SauceLabs website
	When I input the <User>
	And input <password>
	Then the home page will load

Examples:
	| User          | password     |
	| standard_user | secret_sauce |
	#| problem_user    | secret_sauce    |
	#| locked_out_user | secret_sauce    |