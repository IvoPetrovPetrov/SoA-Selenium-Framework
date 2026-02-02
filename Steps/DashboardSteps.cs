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
        private readonly ScenarioContext _context;

        public DashboardSteps(ScenarioContext scenario, DashboardPage dashboardPage, SettingsModel model)
        {
            this._dashboardPage = dashboardPage;
            this._settingsModel = model;
            this._context = scenario;
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

        [When("I should see the logged registered user")]
        public void WhenIShouldSeeTheLoggedRegisteredUser()
        {
            _dashboardPage.VerifyLoggedUserEmailIs(_context.Get<string>("userMail"));
        }

        [When("I open Users list page")]
        public void WhenIOpenUsersListPage()
        {
            _dashboardPage.OpenUsersMenu();
        }
    }
}