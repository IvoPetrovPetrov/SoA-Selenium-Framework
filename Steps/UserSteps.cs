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
        private ScenarioContext _context;

        private readonly SettingsModel _settingsModel;
        private ICollection<IWebElement> UsersEmails => _driver.FindElements(By.XPath("//table//td[6]"));


        public UserSteps(ScenarioContext scenario, IWebDriver driver, UsersPage usersPage, SettingsModel model)
        {
            this._usersPage = usersPage;
            this._context = scenario;
            this._driver = driver;
            this._settingsModel = model;
        }

        [When("I delete the newly registered user")]
        public void WhenIDeleteTheNewlyRegisteredUser()
        {
            _usersPage.DeleteUserByEmail(_context.Get<string>("userMail"));
        }

        [When("I see the deleted user is not in the User list anymore")]
        public void WhenISeeTheDeletedUserIsNotInTheUserListAnymore()
        {
            var email = _context.Get<string>("userMail");
            _usersPage.VerifyUserIsDeletedByEmail(_context.Get<string>("userMail"));

        }
    }
}
