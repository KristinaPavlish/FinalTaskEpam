using FinalTaskEpam.TestProject.Base;
using FinalTaskEpam.TestProject.Pages;
using FinalTaskEpam.TestProject.TestData;
using FluentAssertions;

namespace FinalTaskEpam.TestProject.Tests;

/// <summary>
/// UC-1: Login validation when password field is cleared.
/// </summary>
[TestFixture(BrowserType.Chrome)]
[TestFixture(BrowserType.Firefox)]
public class Uc1LoginValidationTests : BaseTest
{
    public Uc1LoginValidationTests(BrowserType browserType) : base(browserType)
    {
    }

    [TestCaseSource(typeof(LoginTestData), nameof(LoginTestData.Usernames))]
    public void Login_WithEmptyPassword_ShouldShowPasswordRequiredError(string username)
    {
        Logger.Info($"UC-1 started. Browser: {Driver.GetType().Name}, Username: {username}");

        var loginPage = new LoginPage(Driver);

        Logger.Info("Opening login page");
        loginPage.Open(BaseUrl);

        Logger.Info($"Entering username: {username}");
        loginPage.EnterUsername(username);

        Logger.Info("Entering password");
        loginPage.EnterPassword(TestUsers.Password);

        Logger.Info("Clearing password field");
        loginPage.ClearPassword();

        Logger.Info("Clicking Login button");
        loginPage.ClickLogin();

        var actualError = loginPage.GetErrorMessage();
        Logger.Info($"Actual error: '{actualError}'");
        actualError.Should().Be("Epic sadface: Password is required");

        Logger.Info("UC-1 finished successfully");
    }
}
