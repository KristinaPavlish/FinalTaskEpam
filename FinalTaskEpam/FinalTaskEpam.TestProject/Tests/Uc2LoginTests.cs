using FinalTaskEpam.TestProject.Base;
using FinalTaskEpam.TestProject.Pages;
using FinalTaskEpam.TestProject.TestData;
using FluentAssertions;

namespace FinalTaskEpam.TestProject.Tests;

/// <summary>
/// UC-2: Login with valid credentials and verify main page elements.
/// </summary>
[TestFixture(BrowserType.Chrome)]
[TestFixture(BrowserType.Firefox)]
public class Uc2LoginTests : BaseTest
{
    public Uc2LoginTests(BrowserType browserType) : base(browserType)
    {
    }

    [TestCaseSource(typeof(LoginTestData), nameof(LoginTestData.ValidUsers))]
    public void Login_WithValidCredentials_ShouldDisplayMainPageElements(LoginTestCase testCase)
    {
        Logger.Info($"UC-2 started. Browser: {Driver.GetType().Name}, Username: {testCase.Username}");

        var loginPage = new LoginPage(Driver);
        var productsPage = new ProductsPage(Driver);

        Logger.Info("Opening login page");
        loginPage.Open(BaseUrl);

        Logger.Info($"Logging in as {testCase.Username}");
        loginPage.Login(testCase.Username, testCase.Password);

        Logger.Info("Verifying main page elements");
        productsPage.IsBurgerMenuDisplayed().Should().BeTrue();
        productsPage.GetLogoText().Should().Be("Swag Labs");
        productsPage.IsShoppingCartDisplayed().Should().BeTrue();
        productsPage.IsSortDropdownDisplayed().Should().BeTrue();
        productsPage.GetInventoryItemsCount().Should().BeGreaterThan(0);

        Logger.Info("UC-2 finished successfully");
    }
}
