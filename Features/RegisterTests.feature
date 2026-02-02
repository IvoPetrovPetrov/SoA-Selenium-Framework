Feature: RegisterTests

A new user is able to register successfully, and the super admin can manage and delete it
from the Users List page. The deleted user is not able to login again.


Scenario: User is able to register, super admin can delete the user, and deleted user cannot login
	Given I navigate to the register page and sign up with a new user
	When I should see the logged registered user
	And I should be able to logout successfully
	And I login with valid credentials
	And I open Users list page
	And I delete the newly registered user
	And I see the deleted user is not in the User list anymore
	And I should be able to logout successfully
	And I try to login with deleted user again
	Then I should an error message with the following text "Invalid email or password"