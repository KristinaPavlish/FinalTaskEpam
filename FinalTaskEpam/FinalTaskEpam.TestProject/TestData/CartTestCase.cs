namespace FinalTaskEpam.TestProject.TestData;

public class CartTestCase
{
    public string Username { get; set; } = string.Empty;

    public string Password { get; set; } = string.Empty;

    public string ProductName { get; set; } = string.Empty;

    public int ExpectedCartCount { get; set; } = 1;

    public override string ToString()
    {
        return ProductName;
    }
}
