namespace FinalTaskEpam.TestProject.TestData;

public static class CartTestData
{
    /// <summary>
    /// Test data for UC-3 (add product, check badge and cart items count).
    /// </summary>
    public static IEnumerable<CartTestCase> ProductsToAdd()
    {
        yield return new CartTestCase
        {
            Username = TestUsers.StandardUser,
            Password = TestUsers.Password,
            ProductName = "Sauce Labs Backpack",
            ExpectedCartCount = 1
        };

        yield return new CartTestCase
        {
            Username = TestUsers.StandardUser,
            Password = TestUsers.Password,
            ProductName = "Sauce Labs Bike Light",
            ExpectedCartCount = 1
        };
    }
}
