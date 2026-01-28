using OpenQA.Selenium;
using Reqnroll;
using SeleniumFramework.Models;
using SeleniumFramework.Pages;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace SeleniumFramework.Steps
{
    [Binding]
    public class UserSteps
    {
        private IWebDriver _driver;
        private UsersPage _registerPage;

        private readonly SettingsModel _settingsModel;
        private ICollection<IWebElement> UsersEmails => _driver.FindElements(By.XPath("//table//td[6]"));


        public UserSteps(IWebDriver driver, SettingsModel model)
        {
            this._driver = driver;
            this._settingsModel = model;
        }

        [When("I open Users list page")]
        public void WhenIOpenUsersListPage()
        {
            var dashboardPage = new DashboardPage(_driver);
            dashboardPage.OpenUsersMenu();
        }

        [When("I delete the newly registered user {string}")]
        public void WhenIDeleteTheNewlyRegisteredUser(string email)
        {
            var usersPage = new UsersPage(_driver);
            usersPage.DeleteUserByEmail(email);
        }

        [When("I see the deleted user is not in the User list anymore {string}")]
        public void WhenISeeTheDeletedUserIsNotInTheUserListAnymore(string email)
        {
            var usersPage = new UsersPage(_driver);
            bool userExists = UsersEmails.Any(e => e.Text == email); ;
            Assert.That(userExists, Is.False, $"User with email '{email}' was not deleted.");
        }

    }
}
