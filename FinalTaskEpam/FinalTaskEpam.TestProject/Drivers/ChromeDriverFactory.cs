using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace FinalTaskEpam.TestProject.Drivers;

/// <summary>
/// Factory that creates a configured Chrome WebDriver.
/// </summary>
public class ChromeDriverFactory : IWebDriverFactory
{
    /// <inheritdoc />
    public IWebDriver CreateDriver()
    {
        var options = new ChromeOptions();
        options.AddArgument("--incognito");
        options.AddArgument("--disable-save-password-bubble");
        options.AddUserProfilePreference("credentials_enable_service", false);
        options.AddUserProfilePreference("profile.password_manager_enabled", false);
        options.AddUserProfilePreference("profile.password_manager_leak_detection", false);
        options.AddUserProfilePreference("autofill.profile_enabled", false);

        return new ChromeDriver(options);
    }
}
