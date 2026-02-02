using OpenQA.Selenium;
using Reqnroll;
using SeleniumFramework.Models;
using SeleniumFramework.Pages;

namespace SeleniumFramework.Steps
{
    [Binding]
    public class UserSteps
    {
        private IWebDriver _driver;
        private UsersPage _usersPage;

        private readonly SettingsModel _settingsModel;
        private ICollection<IWebElement> UsersEmails => _driver.FindElements(By.XPath("//table//td[6]"));


        public UserSteps(IWebDriver driver, UsersPage usersPage, SettingsModel model)
        {
            this._usersPage = _usersPage;
            this._driver = driver;
            this._settingsModel = model;
        }

        [When("I delete the newly registered user {string}")]
        public void WhenIDeleteTheNewlyRegisteredUser(string email)
        {
            _usersPage.DeleteUserByEmail(email);
        }

        [When("I see the deleted user is not in the User list anymore {string}")]
        public void WhenISeeTheDeletedUserIsNotInTheUserListAnymore(string email)
        {
            //var usersPage = new UsersPage(_driver);
            bool userExists = UsersEmails.Any(e => e.Text == email); ;
            Assert.That(userExists, Is.False, $"User with email '{email}' was not deleted.");
        }

    }
}
