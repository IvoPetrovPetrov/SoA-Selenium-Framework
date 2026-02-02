using OpenQA.Selenium;
using Reqnroll;
using SeleniumFramework.Models;
using SeleniumFramework.Pages;

namespace SeleniumFramework.Steps
{
    [Binding]
    public class DashboardSteps
    {
        private readonly DashboardPage _dashboardPage;
        private readonly SettingsModel _settingsModel;

        public DashboardSteps(DashboardPage dashboardPage, SettingsModel model)
        {
            this._dashboardPage = dashboardPage;
            this._settingsModel = model;
        }

        [Then("I should see the logged user in the main header")]
        public void ThenIShouldSeeTheLoggedUserInTheMainHeader()
        {
            _dashboardPage.VerifyLoggedUserEmailIs(_settingsModel.Email);
            _dashboardPage.VerifyUsernameIs(_settingsModel.Username);
        }

        [When("I should be able to logout successfully")]
        public void ThenIShouldBeAbleToLogoutSuccessfully()
        {
            _dashboardPage.Logout();
        }

        [When("I should see the logged user {string}")]
        public void WhenIShouldSeeTheLoggedUser(string email)
        {
            _dashboardPage.VerifyLoggedUserEmailIs(email);
        }

        [When("I open Users list page")]
        public void WhenIOpenUsersListPage()
        {
            _dashboardPage.OpenUsersMenu();
        }
    }
}