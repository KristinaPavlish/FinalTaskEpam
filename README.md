# FinalTaskEpam

UI test automation project for [Sauce Demo](https://www.saucedemo.com/).

## Task description

### UC-1 — Login form with only Username provided
1. Enter any username.
2. Enter password.
3. Clear the **Password** field.
4. Click the **Login** button.
5. Verify that an error message **"Password is required"** appears.

### UC-2 — Login form with valid credentials
1. Enter username for a **standard user**.
2. Enter a password from the section **Password for all users**.
3. Click **Login**.
4. Verify that the main page contains:
   - burger menu button
   - label **Swag Labs**
   - shopping cart icon
   - dropdown with sorting filters
   - list of inventory items

### UC-3 — Adding products to shopping cart
1. Login with **standard user**.
2. Open details of any product by clicking on it.
3. Add product to cart.
4. Verify that the shopping cart icon displays the number of added products.
5. Open the cart and verify that the number of items matches the badge.

## Requirements covered
- Parallel test execution (NUnit fixtures for Chrome and Firefox)
- Logging of execution flow
- Data-driven testing (`TestCaseSource`)

## Tech stack
| Area | Choice |
|---|---|
| Tool | Selenium WebDriver |
| Browsers | Chrome, Firefox |
| Locators | CSS |
| Test runner | NUnit |
| Assertions | FluentAssertions |
| Logging | Log4Net |
| Patterns | Singleton (WebDriver), Abstract Factory (Chrome/Firefox) |

## Architecture notes
- `WebDriverSingleton` — one driver instance per test thread (safe for parallel fixtures)
- `IWebDriverFactory` + `ChromeDriverFactory` / `FirefoxDriverFactory` via `WebDriverFactoryProvider`
- On test failure, `BaseTest.TearDown` logs the error and saves a screenshot to `Screenshots/`

## How to run

```bash
dotnet test FinalTaskEpam/FinalTaskEpam.TestProject/FinalTaskEpam.TestProject.csproj
```

Run a single use case:

```bash
dotnet test --filter "FullyQualifiedName~Uc3AddToCartTests"
```
