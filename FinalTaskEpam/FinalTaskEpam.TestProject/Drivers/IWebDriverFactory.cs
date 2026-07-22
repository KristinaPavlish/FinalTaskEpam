using OpenQA.Selenium;

namespace FinalTaskEpam.TestProject.Drivers;

/// <summary>
/// Abstract factory contract for creating browser-specific WebDriver instances.
/// </summary>
public interface IWebDriverFactory
{
    /// <summary>
    /// Creates and configures a new WebDriver instance.
    /// </summary>
    IWebDriver CreateDriver();
}
