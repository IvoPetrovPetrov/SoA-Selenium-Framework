using OpenQA.Selenium;
using Reqnroll;
using SeleniumFramework.Models;
using SeleniumFramework.Pages;
using SeleniumFramework.Utilities;


namespace SeleniumFramework.Steps
{
    [Binding]
    public class LoginSteps
    {
        private IWebDriver _driver;
        private LoginPage _loginPage;

        private readonly SettingsModel _settingsModel;

        public LoginSteps(IWebDriver driver, LoginPage loginPage, SettingsModel model)
        {
            this._driver = driver;
            this._loginPage = loginPage;
            this._settingsModel = model;
        }

        [Given("I navigate to the main page")]
        public void GivenINavigateToTheMainPage()
        {
            _driver.Navigate().GoToUrl(_settingsModel.BaseUrl);
        }

        [Given("I verify that the login form is displayed")]
        public void GivenIVerifyThatTheLoginFormIsDisplayed()
        {
            _loginPage.VerifyTheFormIsVisible();
        }

        [When("I login with valid credentials")]
        public void WhenILoginWithValidCredentials()
        {
            _loginPage.LoginWith(_settingsModel.Email, _settingsModel.Password);
        }

        [When("I login with invalid credentials")]
        public void WhenILoginWithInvalidCredentials()
        {
            _loginPage.LoginWith("notexistinguser@gmail.com", _settingsModel.Password);
        }

        [When("I login with {string} and {string}")]
        public void WhenILoginWithAnd(string email, string password)
        {
            if (email == "readFromSettings")
            {
                WhenILoginWithValidCredentials();
            }
            else
                _loginPage.LoginWith(email, password);
        }

        [When("I try to login with deleted user again {string} and {string}")]
        public void WhenITryToLoginWithDeletedUserAgainAnd(string email, string password)
        {
            _loginPage.LoginWith(email, password);
        }

        [Then("I should still be on the login page")]
        public void ThenIShouldStillBeOnTheLoginPage()
        {
            Assert.That(_driver.Url, Is.EqualTo(_settingsModel.BaseUrl + "login.php"));
        }

        [Then("I should an error message with the following text {string}")]
        public void ThenIShouldAnErrorMessageWithTheFollowingText(string errorText)
        {
            Retry.Until(() =>
            {
                if (!_loginPage.IsPasswordEmpty())
                    throw new RetryException("Password input is not empty yet.");
            });

            _loginPage.VerifyPasswordInputIsEmpty();
            _loginPage.VerifyErrorMessageIsDisplayed(errorText);
        }
    }
}