using FinalTaskEpam.TestProject.Base;

namespace FinalTaskEpam.TestProject.Drivers;

/// <summary>
/// Provides a concrete WebDriver factory based on the requested browser type (Abstract Factory).
/// </summary>
public static class WebDriverFactoryProvider
{
    /// <summary>
    /// Returns a browser-specific <see cref="IWebDriverFactory"/>.
    /// </summary>
    public static IWebDriverFactory GetFactory(BrowserType browserType)
    {
        return browserType switch
        {
            BrowserType.Chrome => new ChromeDriverFactory(),
            BrowserType.Firefox => new FirefoxDriverFactory(),
            _ => throw new ArgumentOutOfRangeException(nameof(browserType), browserType, "Unknown browser type")
        };
    }
}
