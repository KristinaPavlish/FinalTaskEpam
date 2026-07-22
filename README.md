# FinalTaskEpam

UI test automation project for [Sauce Demo](https://www.saucedemo.com/).

**Author:** Kristina Kikhtan

---

## Initial task requirements

Site for testing: https://www.saucedemo.com/

### UC-1 — Test Login form with only Username provided
1. Enter any username.
2. Enter password.
3. Clear the **Password** field.
4. Click the **Login** button.
5. Verify that an error message **"Password is required"** appears.

### UC-2 — Test Login form with valid credentials
1. Enter username for a **standard user**.
2. Enter a password from the section **Password for all users**.
3. Click **Login**.
4. Verify that the main page contains:
   - burger menu button
   - label **Swag Labs**
   - shopping cart icon
   - dropdown with sorting filters
   - list of inventory items

### UC-3 — Test adding products to shopping cart
1. Login with **standard user**.
2. Open details of any product by clicking on it.
3. Add product to cart.
4. Verify that the shopping cart icon displays the number of added products.

### Cross-cutting requirements
- Possibility to execute tests in **parallel**
- **Logging** to track execution flow
- **Data-driven** testing approach
- All of the above must support UC-1, UC-2, and UC-3

### Required tech options
| Area | Choice |
|---|---|
| Test Automation tool | Selenium WebDriver |
| Browsers | Firefox, Chrome |
| Locators | CSS |
| Test Runner | NUnit |
| Assertions | FluentAssertions |
| Patterns (optional) | Singleton, Factory method, Abstract Factory |
| Loggers (optional) | Log4Net / NUnit |

---

## What was implemented

### Use cases
- **UC-1** — empty password validation with data-driven usernames (Chrome + Firefox)
- **UC-2** — successful login as `standard_user` and verification of main page elements
- **UC-3** — open product details, add to cart, verify cart badge and cart items count

### Architecture
- **Page Object Model** — `LoginPage`, `ProductsPage`, `ProductDetailsPage`, `CartPage`
- **Singleton** — `WebDriverSingleton` (one driver per test thread, safe for parallel runs)
- **Abstract Factory** — `IWebDriverFactory` + `ChromeDriverFactory` / `FirefoxDriverFactory`
- **Parallel execution** — NUnit `[TestFixture(BrowserType.Chrome)]` / `[TestFixture(BrowserType.Firefox)]`
- **Data-driven tests** — `TestCaseSource` (`LoginTestData`, `CartTestData`)
- **Log4Net** — file + console logging (`Logs/TestExecution.log`)
- **Error handling** — on failure: error log + screenshot in `Screenshots/`

### Project structure
```
FinalTaskEpam/
├── FinalTaskEpam.TestProject/
│   ├── Base/           # BaseTest, Logger, BrowserType
│   ├── Drivers/        # Singleton + Factory for WebDriver
│   ├── Pages/          # Page Object Model
│   ├── TestData/       # Data-driven test data
│   ├── Tests/          # UC-1, UC-2, UC-3
│   └── log4net.config
└── FinalTaskEpam.sln
```

---

## Prerequisites
- .NET 8 SDK
- Google Chrome
- Mozilla Firefox

## How to run

```bash
dotnet test FinalTaskEpam/FinalTaskEpam.TestProject/FinalTaskEpam.TestProject.csproj
```

Run a single use case:

```bash
dotnet test --filter "FullyQualifiedName~Uc1LoginValidationTests"
dotnet test --filter "FullyQualifiedName~Uc2LoginTests"
dotnet test --filter "FullyQualifiedName~Uc3AddToCartTests"
```
