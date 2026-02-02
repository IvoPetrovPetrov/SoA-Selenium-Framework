using OpenQA.Selenium;
using SeleniumFramework.Extensions;

namespace SeleniumFramework.Pages
{
    public class DashboardPage
    {
        private readonly IWebDriver _driver;

        private IWebElement LoggedUserAnchor => _driver.FindElement(By.XPath("//a[@id='navbarDropdown']"));
        private IWebElement UsernameHeader => _driver.FindElement(By.XPath("//div[contains(@class, 'container-fluid')]/h1"));
        private IWebElement UsersButton => _driver.FindElement(By.XPath("//div[@id='navbar']//a[contains(text(), 'Users')]"));
        private IWebElement LogoutButton => _driver.FindElement(By.XPath("//a[contains(text(),'Logout')]"));
        
        public DashboardPage(IWebDriver driver)
        {
            this._driver = driver;
        }

        public void VerifyLoggedUserEmailIs(string expectedUserEmail)
        {
            string actualUserEmail = this.LoggedUserAnchor.Text.Trim();

            Assert.That(actualUserEmail, Is.EqualTo(expectedUserEmail));
        }

        public void VerifyUsernameIs(string username)
        { 
            string headerText = this.UsernameHeader.Text.Trim();
            Assert.That(headerText.Contains(username), Is.True);
        }

        public void Logout()
        {
            LoggedUserAnchor.Click();
            _driver.WaitUntilElementIsClickable(this.LogoutButton);
            LogoutButton.Click();
        }

        public void OpenUsersMenu()
        {
            UsersButton.Click();
        }
    }
}
