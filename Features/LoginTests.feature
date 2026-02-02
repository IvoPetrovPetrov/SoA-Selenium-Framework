Feature: LoginTests

As an user i want to be able to navigate to the main page of the website and being able to login with existing 
credentials. Where non-valid credentials are provided, an appropriate error message and validation is displayed.

Background:
	Given I navigate to the main page
	And I verify that the login form is displayed

@Login
@Smoke
Scenario: Login with existing user, should be successful and the dashboard should be displayed
	When I login with valid credentials
	Then I should see the logged user in the main header
	Then I should be able to logout successfully

@Login
@Smoke
Scenario: Login with non-existing user, should not be successful and error message is present
	When I login with invalid credentials
	Then I should still be on the login page
	And I should an error message with the following text "Invalid email or password"

@Login
@Smoke
Scenario Outline: Login specific user with predefined role, should be successful and the dashboard should be displayed
	When I login with "<email>" and "<password>"
	Then I should see the logged user in the main header
	And I should be able to logout successfully

Examples:
	| email                      | password         |
	| test@abv.bg                |           123456 |
	| readFromSettings           | readFromSettings |
	| shouldfailaswell@gmail.com |                  |

@E2E
Scenario: Verify a registered user can be deleted by an admin user and the cannot login afterwards
	
	Given I register a new user - RegisterSteps (RegisterPage)
	And I login with admin credentials (LoginSteps) (LoginPage)
	And I navigate to the users page (DashboardSteps) (DashboardPage)

	When I delete the created user (UsersSteps) (UsersPage)
	And I log out successefuly 

	Then I login with the deleted user's credentials
	And I should still be on the login page
	And I should see an error message with the following text "Invalid email or password"

