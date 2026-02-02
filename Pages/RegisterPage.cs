using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using Reqnroll;
using SeleniumFramework.Models;

namespace SeleniumFramework.Pages
{
    public class RegisterPage
    {
        private readonly IWebDriver _driver;

        // Elements
        private IWebElement TitleDropdown => _driver.FindElement(By.XPath("//select[@id='title']"));
        private IWebElement TitleDropdownMr => _driver.FindElement(By.XPath("//option[@value='Mr.']"));
        private IWebElement TitleDropdownMrs => _driver.FindElement(By.XPath("//option[@value='Mrs.']"));
        private IWebElement FirstNameInput => _driver.FindElement(By.XPath("//input[@id='first_name']"));
        private IWebElement SurNameInput => _driver.FindElement(By.XPath("//input[@id='sir_name']"));
        private IWebElement EmailInput => _driver.FindElement(By.XPath("//input[@id='email']"));
        private IWebElement PasswordInput => _driver.FindElement(By.XPath("//input[@id='pass']"));
        private IWebElement Country => _driver.FindElement(By.XPath("//input[@id='country']"));
        private IWebElement City => _driver.FindElement(By.XPath("//input[@id='city']"));
        private IWebElement RadioTermsButton => _driver.FindElement(By.XPath("//input[@id='tos']"));
        private IWebElement RegisterButton => _driver.FindElement(By.XPath("//button[@type='submit' and contains(text(), 'Register')]"));
        private IWebElement AlreadyHaveAccountButton => _driver.FindElement(By.XPath("//a[@class='btn btn-link' and text()='Already have an account? Login here']\r\n"));
        private IWebElement NavBarButton => _driver.FindElement(By.XPath("//span[@class='navbar-toggler-icon']"));
        private IWebElement NavBarMenu => _driver.FindElement(By.XPath("//div[@class='container']"));
        private IWebElement NavBarHomeButton => _driver.FindElement(By.XPath("//a[contains(@class,'nav-link') and text()='Home']"));
        private IWebElement NavBarLoginButton => _driver.FindElement(By.XPath("//a[contains(@class,'nav-link') and text()='Login']"));
        private IWebElement NavBarRegisterButton => _driver.FindElement(By.XPath("//a[contains(@class,'nav-link') and text()='Register']"));
        private IWebElement ErrorFirstNameValidationMessage => _driver.FindElement(By.XPath("//input[@id='first_name']//following-sibling::div[@class='invalid-feedback']"));

        public RegisterPage(IWebDriver driver)
        {
            this._driver = driver;
        }

        public UserModel GetUserInformation()
        {
            var user = new UserModel
            {
                FirstName = "John",
                Surname = "Doe",
                Email = $"johndoe{Guid.NewGuid()}@example.com",
                Password = "Password123!",
                Country = "USA",
                City = "New York"
            };            
            return user;
        }

        public void PopulateRegistrationForm(UserModel user)
        {
            FirstNameInput.SendKeys(user.FirstName);
            SurNameInput.SendKeys(user.Surname);
            EmailInput.SendKeys(user.Email);
            PasswordInput.SendKeys(user.Password);
            Country.SendKeys(user.Country);
            City.SendKeys(user.City);
        }

        public void TermsAndConditionsClick()
        {
            new Actions(_driver)
                .ScrollToElement(RadioTermsButton)
                .Perform();

            RadioTermsButton.Click();
        }

        public void ClickRegisterButton()
        {
            new Actions(_driver)
                .ScrollToElement(RegisterButton)
                .Perform();

            RegisterButton.Click();
        }

        public void InvalidNameFormat(string name)
        {
            this.FirstNameInput.SendKeys(name);
            if (name.Any(char.IsDigit) || name.Length < 2 || name.Length > 15)
            {
                throw new ArgumentException("Invalid name format. Name must contain only letters and be between 2 and 15 characters long.");
            }
            //I need to restrict the name to be letters only, 2-15 characters).
        }
    }
}
