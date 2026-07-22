using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace FinalTaskEpam.TestProject.Drivers;

/// <summary>
/// Factory that creates a configured Firefox WebDriver.
/// </summary>
public class FirefoxDriverFactory : IWebDriverFactory
{
    /// <inheritdoc />
    public IWebDriver CreateDriver()
    {
        return new FirefoxDriver();
    }
}
