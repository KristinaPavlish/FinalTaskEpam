using OpenQA.Selenium;

namespace FinalTaskEpam.TestProject.Pages;

/// <summary>
/// Page object for the Sauce Demo login page.
/// </summary>
public class LoginPage : BasePage
{
    private readonly By _usernameInput = By.CssSelector("#user-name");
    private readonly By _passwordInput = By.CssSelector("#password");
    private readonly By _loginButton = By.CssSelector("#login-button");
    private readonly By _errorMessage = By.CssSelector("h3[data-test='error']");

    public LoginPage(IWebDriver driver) : base(driver)
    {
    }

    /// <summary>
    /// Opens the given URL in the browser.
    /// </summary>
    public void Open(string url)
    {
        Driver.Navigate().GoToUrl(url);
    }

    /// <summary>
    /// Types the username into the username field.
    /// </summary>
    public void EnterUsername(string username)
    {
        WaitForVisible(_usernameInput).SendKeys(username);
    }

    /// <summary>
    /// Types the password into the password field.
    /// </summary>
    public void EnterPassword(string password)
    {
        WaitForVisible(_passwordInput).SendKeys(password);
    }

    /// <summary>
    /// Clears the password field using keyboard actions (React-friendly for Chrome).
    /// </summary>
    public void ClearPassword()
    {
        ClearInput(_passwordInput);
    }

    /// <summary>
    /// Clears the username field using keyboard actions.
    /// </summary>
    public void ClearUsername()
    {
        ClearInput(_usernameInput);
    }

    /// <summary>
    /// Clicks the Login button.
    /// </summary>
    public void ClickLogin()
    {
        WaitForClickable(_loginButton).Click();
    }

    /// <summary>
    /// Performs a full login with username and password.
    /// </summary>
    public void Login(string userName, string password)
    {
        EnterUsername(userName);
        EnterPassword(password);
        ClickLogin();
    }

    /// <summary>
    /// Returns the login error message text.
    /// </summary>
    public string GetErrorMessage()
    {
        return WaitForVisible(_errorMessage).Text;
    }

    /// <summary>
    /// Returns true when navigation reaches the inventory page.
    /// </summary>
    public bool IsLoginSuccessful()
    {
        return WaitForUrlContains("inventory.html");
    }

    private void ClearInput(By locator)
    {
        var input = WaitForVisible(locator);
        input.Click();
        input.SendKeys(Keys.Control + "a");
        input.SendKeys(Keys.Delete);

        if (!string.IsNullOrEmpty(input.GetAttribute("value")))
        {
            input.SendKeys(Keys.Control + "a");
            input.SendKeys(Keys.Backspace);
        }
    }
}
