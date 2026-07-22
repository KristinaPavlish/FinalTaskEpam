using OpenQA.Selenium;

namespace FinalTaskEpam.TestProject.Pages;

/// <summary>
/// Page object for a single product details page.
/// </summary>
public class ProductDetailsPage : BasePage
{
    private readonly By _productTitle = By.CssSelector(".inventory_details_name");
    private readonly By _addToCartButton = By.CssSelector("button[data-test='add-to-cart']");

    public ProductDetailsPage(IWebDriver driver) : base(driver)
    {
    }

    /// <summary>
    /// Returns the product title from the details page.
    /// </summary>
    public string GetProductName()
    {
        return WaitForVisible(_productTitle).Text;
    }

    /// <summary>
    /// Clicks the Add to cart button.
    /// </summary>
    public void AddToCart()
    {
        WaitForClickable(_addToCartButton).Click();
    }
}
