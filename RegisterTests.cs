using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumFramework.Models;
using SeleniumFramework.Pages;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace SeleniumFramework
{
    [TestFixture]
    public class RegisterTests
    {
        private IWebDriver _driver;
        private RegisterPage _registerPage;
        private DashboardPage _dashboardPage;
        private LoginPage _loginPage;
        private UsersPage _usersPage;

        private readonly SettingsModel _settingsModel;

        public RegisterTests()
        {
            _settingsModel = Utilities.ConfigurationManager.Instance.SettingsModel;
        }

        [SetUp]

        public void Setup()
        {
            new DriverManager().SetUpDriver(new ChromeConfig());
            _driver = new ChromeDriver();
            _driver.Manage().Window.Maximize();
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            _registerPage = new RegisterPage(_driver);
            _dashboardPage = new DashboardPage(_driver);
            _loginPage = new LoginPage(_driver);
            _usersPage = new UsersPage(_driver);
            _driver.Navigate().GoToUrl(_settingsModel.RegisterPage);
        }

        [TearDown]
        public void TearDown()
        {
            _driver.Quit();
            _driver.Dispose();
        }

        [Test]
        [Category("Registration")]
        public void ValidRegistration()
        {
            string firstname = "test";
            string surname = "ivo";
            string email = "testvio@test.com";
            string password = "123456";
            string country = "Bulgaria";
            string city = "Plovdiv";

            _registerPage.PopulateRegistrationForm(firstname, surname, email, password, country, city);
            _registerPage.TermsAndConditionsClick();
            _registerPage.ClickRegisterButton();
            _dashboardPage.VerifyLoggedUserEmailIs(email);

            _dashboardPage.Logout();
            _loginPage.LoginWith(_settingsModel.Email, _settingsModel.Password);

            _dashboardPage.OpenUsersMenu();

            _usersPage.DeleteUserByEmail(email);
            _usersPage.VerifyUserIsDeletedByEmail(email);
            _dashboardPage.Logout();

            _loginPage.LoginWith(email, password);
            _loginPage.VerifyErrorMessageIsDisplayed("Invalid email or password");

        }
    }
}
