using Microsoft.Extensions.DependencyInjection;
using MySqlConnector;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Reqnroll.Microsoft.Extensions.DependencyInjection;
using SeleniumFramework.DatabaseOperations.Operations;
using SeleniumFramework.Models;
using SeleniumFramework.Pages;
using SeleniumFramework.Utilities;
using System.Data;

namespace SeleniumFramework.Hooks
{
    public class DependencyContainer
    {
        [ScenarioDependencies]
        public static IServiceCollection RegisterDependencies()
        {
            var services = new ServiceCollection();
            services.AddSingleton(sp =>
            {
                return ConfigurationManager.Instance.SettingsModel;
            });

            services.AddScoped<IWebDriver>(sp =>
            {
                //new DriverManager().SetUpDriver(new ChromeConfig());

                var driver = new ChromeDriver();
                driver.Manage().Window.Maximize();
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);

                return driver;
            });

            services.AddScoped(sp =>
            {
                var driver = sp.GetRequiredService<IWebDriver>();
                return new LoginPage(driver);
            });

            services.AddScoped(sp =>
            {
                var driver = sp.GetRequiredService<IWebDriver>();
                return new DashboardPage(driver);
            });

            services.AddScoped(sp =>
            {
                var driver = sp.GetRequiredService<IWebDriver>();
                return new UsersPage(driver);
            });
            services.AddScoped(sp => 
            {
                var driver = sp.GetRequiredService<IWebDriver>();
                return new RegisterPage(driver);
            });

            services.AddScoped<IDbConnection>(sp =>
            {
                var settings = sp.GetRequiredService<SettingsModel>();
                var connectionString = settings.ConnectionString;

                var dbConnection = new MySqlConnection(connectionString);
                return dbConnection;
            });

            services.AddScoped(sp =>
            {
                var dbConnection = sp.GetRequiredService<IDbConnection>();
                return new UserOperations(dbConnection);
            });

            return services;
        }
    }
}