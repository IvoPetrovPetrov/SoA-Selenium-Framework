using OpenQA.Selenium;

namespace SeleniumFramework.Pages
{
    public class UsersPage
    {
        private readonly IWebDriver _driver;
        private IWebElement DeleteForUserByEmail(string email) => _driver.FindElement(By.XPath($"//td[6][text()='{email}']/..//td[7]/a"));
        private ICollection<IWebElement> UsersEmails => _driver.FindElements(By.XPath("//table//td[6]"));

        public UsersPage(IWebDriver driver)
        {
            this._driver = driver;
        }

        public void DeleteUserByEmail(string email)
        {
            DeleteForUserByEmail(email).Click();
            _driver.SwitchTo().Alert().Accept();
        }

        public void VerifyUserIsDeletedByEmail(string email)
        {
            bool userExists = UsersEmails.Any(e => e.Text == email);
            Assert.That(userExists, Is.False, $"User with email '{email}' was not deleted.");
        }

    }
}
