using FinalTaskEpam.TestProject.Base;
using OpenQA.Selenium;

namespace FinalTaskEpam.TestProject.Drivers;

/// <summary>
/// Thread-safe Singleton that holds one WebDriver instance per test thread.
/// ThreadLocal storage keeps parallel Chrome/Firefox fixtures isolated.
/// </summary>
public sealed class WebDriverSingleton
{
    private static readonly ThreadLocal<IWebDriver?> Drivers = new();

    private WebDriverSingleton()
    {
    }

    /// <summary>
    /// Gets the WebDriver for the current thread, creating it via factory if needed.
    /// </summary>
    public static IWebDriver GetInstance(BrowserType browserType)
    {
        if (Drivers.Value != null)
        {
            return Drivers.Value;
        }

        var factory = WebDriverFactoryProvider.GetFactory(browserType);
        Drivers.Value = factory.CreateDriver();
        return Drivers.Value;
    }

    /// <summary>
    /// Quits and clears the WebDriver for the current thread.
    /// </summary>
    public static void QuitInstance()
    {
        try
        {
            Drivers.Value?.Quit();
        }
        finally
        {
            Drivers.Value = null;
        }
    }

    /// <summary>
    /// Clears the current-thread driver reference without quitting (when already closed).
    /// </summary>
    public static void ReleaseInstance()
    {
        Drivers.Value = null;
    }
}
