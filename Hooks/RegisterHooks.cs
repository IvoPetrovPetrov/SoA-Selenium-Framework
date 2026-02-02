using OpenQA.Selenium;
using Reqnroll;
using SeleniumFramework.DatabaseOperations.Operations;

namespace SeleniumFramework.Hooks
{
    [Binding]
    public class RegisterHooks
    {
        private readonly IWebDriver _driver;
        private readonly UserOperations _userOperations;

        public RegisterHooks(IWebDriver webDriver, UserOperations userOperations)
        {
            this._driver = webDriver;
            this._userOperations = userOperations;
        }

        [AfterScenario]
        public void CloserBrowser()
        {
            _driver.Quit();
        }

        [AfterScenario(Order = 9999)]
        public void DeleteCurrentUser()
        {
            _userOperations.DeleteUserWithEmail("idimitrov@automation.com");
        }
    }
}