Feature: Login SauceLabs

 Validate users and credentials levels

@AccessValidation
Scenario Outline: LoginValidation
	Given I access the SauceLabs website
	When I input the <User>
	And input <password>
	Then the home page will load if the user have access

Examples:
	| User            | password     | can Access |
	| standard_user   | secret_sauce | True       |
	| problem_user    | secret_sauce | True       |
	| locked_out_user | secret_sauce | False      |