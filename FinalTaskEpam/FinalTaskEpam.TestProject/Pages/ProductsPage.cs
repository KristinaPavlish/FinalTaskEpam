using OpenQA.Selenium;

namespace FinalTaskEpam.TestProject.Pages;

/// <summary>
/// Page object for the inventory / products page.
/// </summary>
public class ProductsPage : BasePage
{
    private readonly By _burgerMenuButton = By.CssSelector("#react-burger-menu-btn");
    private readonly By _appLogo = By.CssSelector(".app_logo");
    private readonly By _shoppingCartIcon = By.CssSelector(".shopping_cart_link");
    private readonly By _shoppingCartBadge = By.CssSelector(".shopping_cart_badge");
    private readonly By _sortDropdown = By.CssSelector(".product_sort_container");
    private readonly By _inventoryItems = By.CssSelector(".inventory_list .inventory_item");
    private readonly By _productNames = By.CssSelector(".inventory_item_name");

    public ProductsPage(IWebDriver driver) : base(driver)
    {
    }

    /// <summary>
    /// Returns whether the burger menu button is displayed.
    /// </summary>
    public bool IsBurgerMenuDisplayed()
    {
        return WaitForVisible(_burgerMenuButton).Displayed;
    }

    /// <summary>
    /// Returns the application logo text.
    /// </summary>
    public string GetLogoText()
    {
        return WaitForVisible(_appLogo).Text;
    }

    /// <summary>
    /// Returns whether the shopping cart icon is displayed.
    /// </summary>
    public bool IsShoppingCartDisplayed()
    {
        return WaitForVisible(_shoppingCartIcon).Displayed;
    }

    /// <summary>
    /// Returns whether the product sort dropdown is displayed.
    /// </summary>
    public bool IsSortDropdownDisplayed()
    {
        return WaitForVisible(_sortDropdown).Displayed;
    }

    /// <summary>
    /// Returns the number of inventory items on the page.
    /// </summary>
    public int GetInventoryItemsCount()
    {
        WaitForVisible(_inventoryItems);
        return Driver.FindElements(_inventoryItems).Count;
    }

    /// <summary>
    /// Opens product details by clicking the product name.
    /// </summary>
    public void OpenProductByName(string productName)
    {
        WaitForVisible(_productNames);
        var product = Driver.FindElements(_productNames)
            .First(item => item.Text.Equals(productName, StringComparison.OrdinalIgnoreCase));
        product.Click();
    }

    /// <summary>
    /// Opens the shopping cart page.
    /// </summary>
    public void OpenCart()
    {
        WaitForClickable(_shoppingCartIcon).Click();
    }

    /// <summary>
    /// Returns the number shown on the cart badge, or 0 if the badge is missing.
    /// </summary>
    public int GetCartBadgeCount()
    {
        var badges = Driver.FindElements(_shoppingCartBadge);
        if (badges.Count == 0 || !badges[0].Displayed)
        {
            return 0;
        }

        return int.Parse(badges[0].Text);
    }
}
