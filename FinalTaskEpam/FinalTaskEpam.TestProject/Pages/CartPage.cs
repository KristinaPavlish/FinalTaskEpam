using OpenQA.Selenium;

namespace FinalTaskEpam.TestProject.Pages;

/// <summary>
/// Page object for the shopping cart page.
/// </summary>
public class CartPage : BasePage
{
    private readonly By _cartItems = By.CssSelector(".cart_item");
    private readonly By _cartItemNames = By.CssSelector(".cart_item .inventory_item_name");

    public CartPage(IWebDriver driver) : base(driver)
    {
    }

    /// <summary>
    /// Returns the number of items currently in the cart.
    /// </summary>
    public int GetCartItemsCount()
    {
        return Driver.FindElements(_cartItems).Count;
    }

    /// <summary>
    /// Returns the names of all products in the cart.
    /// </summary>
    public IReadOnlyCollection<string> GetCartItemNames()
    {
        return Driver.FindElements(_cartItemNames)
            .Select(item => item.Text)
            .ToList();
    }
}
