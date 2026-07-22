using FinalTaskEpam.TestProject.Base;
using FinalTaskEpam.TestProject.Pages;
using FinalTaskEpam.TestProject.TestData;
using FluentAssertions;

namespace FinalTaskEpam.TestProject.Tests;

/// <summary>
/// UC-3: Add a product from details and verify cart badge and cart items.
/// </summary>
[TestFixture(BrowserType.Chrome)]
[TestFixture(BrowserType.Firefox)]
public class Uc3AddToCartTests : BaseTest
{
    public Uc3AddToCartTests(BrowserType browserType) : base(browserType)
    {
    }

    [TestCaseSource(typeof(CartTestData), nameof(CartTestData.ProductsToAdd))]
    public void AddProductFromDetails_ShouldUpdateCartBadge(CartTestCase testCase)
    {
        Logger.Info($"UC-3 started. Browser: {Driver.GetType().Name}, Product: {testCase.ProductName}");

        var loginPage = new LoginPage(Driver);
        var productsPage = new ProductsPage(Driver);
        var detailsPage = new ProductDetailsPage(Driver);
        var cartPage = new CartPage(Driver);

        Logger.Info("Opening login page");
        loginPage.Open(BaseUrl);

        Logger.Info($"Logging in as {testCase.Username}");
        loginPage.Login(testCase.Username, testCase.Password);

        Logger.Info($"Opening product details: {testCase.ProductName}");
        productsPage.OpenProductByName(testCase.ProductName);
        detailsPage.GetProductName().Should().Be(testCase.ProductName);

        Logger.Info("Adding product to cart");
        detailsPage.AddToCart();

        var badgeCount = productsPage.GetCartBadgeCount();
        Logger.Info($"Cart badge count: {badgeCount}");
        badgeCount.Should().Be(testCase.ExpectedCartCount);

        Logger.Info("Opening cart to verify items count");
        productsPage.OpenCart();

        var cartItemsCount = cartPage.GetCartItemsCount();
        Logger.Info($"Cart items count: {cartItemsCount}");
        cartItemsCount.Should().Be(testCase.ExpectedCartCount);
        cartPage.GetCartItemNames().Should().Contain(testCase.ProductName);

        Logger.Info("UC-3 finished successfully");
    }
}
