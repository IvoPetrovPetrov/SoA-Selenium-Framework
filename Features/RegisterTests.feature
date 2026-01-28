Feature: RegisterTests

A new user is able to register successfully, and the super admin can manage and delete it
from the Users List page. The deleted user is not able to login again.


Scenario: User is able to register, super admin can delete the user, and deleted user cannot login
	Given I navigate to the register page and sign up with a new user
	When I should see the logged user "testvio@test.com"
	And I should be able to logout successfully
	And I login with valid credentials
	And I open Users list page
	And I delete the newly registered user "testvio@test.com"
	And I see the deleted user is not in the User list anymore "testvio@test.com"
	And I should be able to logout successfully
	When I try to login with deleted user again "testvio@test.com" and "123456"
	Then I should an error message with the following text "Invalid email or password"