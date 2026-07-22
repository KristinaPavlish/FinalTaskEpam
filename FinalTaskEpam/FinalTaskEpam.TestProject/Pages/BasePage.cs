using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace FinalTaskEpam.TestProject.Pages;

/// <summary>
/// Base page with shared wait helpers for all page objects.
/// </summary>
public abstract class BasePage
{
    protected readonly IWebDriver Driver;
    protected readonly WebDriverWait Wait;

    protected BasePage(IWebDriver driver)
    {
        Driver = driver;
        Wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(20));
    }

    /// <summary>
    /// Waits until the element is visible and returns it.
    /// </summary>
    protected IWebElement WaitForVisible(By locator)
    {
        return Wait.Until(driver =>
        {
            try
            {
                var element = driver.FindElement(locator);
                return element.Displayed ? element : null;
            }
            catch (NoSuchElementException)
            {
                return null;
            }
            catch (StaleElementReferenceException)
            {
                return null;
            }
        });
    }

    /// <summary>
    /// Waits until the element is visible and clickable and returns it.
    /// </summary>
    protected IWebElement WaitForClickable(By locator)
    {
        return Wait.Until(driver =>
        {
            var element = driver.FindElement(locator);
            return element.Displayed && element.Enabled ? element : null;
        });
    }

    /// <summary>
    /// Waits until the current URL contains the specified fragment.
    /// </summary>
    protected bool WaitForUrlContains(string urlFragment)
    {
        return Wait.Until(driver => driver.Url.Contains(urlFragment));
    }
}
