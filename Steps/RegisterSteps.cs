using OpenQA.Selenium;
using Reqnroll;
using SeleniumFramework.Models;
using SeleniumFramework.Pages;
using SeleniumFramework.Utilities;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumFramework.Steps
{
    [Binding]
    public class RegisterSteps
    {
        private IWebDriver _driver;
        private RegisterPage _registerPage;

        private readonly SettingsModel _settingsModel;

        public RegisterSteps(IWebDriver driver, SettingsModel model)
        {
            this._driver = driver;
            this._settingsModel = model;
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            this._registerPage = new RegisterPage(_driver);
        }

        [AfterScenario]
        public void AfterScenario()
        {
            _driver.Quit();
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
            _registerPage.PopulateRegistrationForm("test", "ivo", "testvio@test.com", "123456", "Bulgaria", "Plovdiv");
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

        [When("I should see the logged user in the main header")]
        public void ThenIShouldSeeTheLoggedUserInTheMainHeader()
        {
            var dashboardPage = new DashboardPage(_driver);
            dashboardPage.VerifyLoggedUserEmailIs(" testvio@test.com");
        }

        [When("I should be able to logout successfully")]
        public void ThenIShouldBeAbleToLogoutSuccessfully()
        {
            var dashboardPage = new DashboardPage(_driver);
            dashboardPage.Logout();
        }



        [When("I should see the logged user {string}")]
        public void WhenIShouldSeeTheLoggedUser(string email)
        {
            var dashboardPage = new DashboardPage(_driver);
            dashboardPage.VerifyLoggedUserEmailIs(email);
        }







    }
}
