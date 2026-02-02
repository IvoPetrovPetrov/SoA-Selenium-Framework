using OpenQA.Selenium;
using Reqnroll;
using SeleniumFramework.Models;
using SeleniumFramework.Pages;

namespace SeleniumFramework.Steps
{
    [Binding]
    public class RegisterSteps
    {
        private IWebDriver _driver;
        private RegisterPage _registerPage;

        private readonly SettingsModel _settingsModel;
        private readonly ScenarioContext _context;


        public RegisterSteps(ScenarioContext scenario, RegisterPage registerPage, IWebDriver driver, SettingsModel model)
        {
            this._driver = driver;
            this._context = scenario;
            this._registerPage = registerPage;
            this._settingsModel = model;
        }

        [Given("I navigate to the register page and sign up with a new user")]
        public void GivenINavigateToTheRegisterPageAndSignUpWithANewUser()
        {
            _driver.Navigate().GoToUrl(_settingsModel.RegisterPage);
            GivenIFillInUserRegistrationForm();
            GivenIClickOnTCButton();
            GivenIClickOnRegisterButton();
        }

        [When("I fill in user registration form")]
        public void GivenIFillInUserRegistrationForm()
        {
            var user = _registerPage.GetUserInformation();
            _context.Add("userMail", user.Email);
            _context.Add("userPassword", user.Password);
            _registerPage.PopulateRegistrationForm(user);
        }

        [When("I click on T&C button")]
        public void GivenIClickOnTCButton()
        {
            _registerPage.TermsAndConditionsClick();
        }

        [When("I click on Register button")]
        public void GivenIClickOnRegisterButton()
        {
            _registerPage.ClickRegisterButton();
        }
    }
}
