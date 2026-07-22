using FinalTaskEpam.TestProject.Drivers;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;

namespace FinalTaskEpam.TestProject.Base;

/// <summary>
/// Base class for all UI tests. Creates a browser via Singleton + Factory and handles failures.
/// </summary>
[Parallelizable(ParallelScope.Fixtures)]
public abstract class BaseTest
{
    protected const string BaseUrl = "https://www.saucedemo.com/";

    private readonly BrowserType _browserType;

    /// <summary>
    /// WebDriver instance for the current test thread.
    /// </summary>
    protected IWebDriver Driver = null!;

    protected BaseTest(BrowserType browserType)
    {
        _browserType = browserType;
    }

    /// <summary>
    /// Initializes WebDriver before each test.
    /// </summary>
    [SetUp]
    public void SetUp()
    {
        Driver = WebDriverSingleton.GetInstance(_browserType);
        Driver.Manage().Window.Maximize();
        Logger.Info($"SetUp completed. Browser: {_browserType}, Test: {TestContext.CurrentContext.Test.Name}");
    }

    /// <summary>
    /// Logs failures, captures a screenshot, and quits WebDriver after each test.
    /// </summary>
    [TearDown]
    public void TearDown()
    {
        try
        {
            var result = TestContext.CurrentContext.Result;
            if (result.Outcome.Status == TestStatus.Failed)
            {
                Logger.Error(
                    $"Test failed: {TestContext.CurrentContext.Test.FullName}. Message: {result.Message}");
                CaptureScreenshot();
            }
        }
        catch (Exception ex)
        {
            Logger.Error("Error while handling test failure in TearDown.", ex);
        }
        finally
        {
            try
            {
                Driver?.Dispose();
            }
            catch (Exception ex)
            {
                Logger.Error("Failed to quit WebDriver.", ex);
            }
            finally
            {
                Driver = null!;
                WebDriverSingleton.ReleaseInstance();
                Logger.Info($"TearDown completed. Test: {TestContext.CurrentContext.Test.Name}");
            }
        }
    }

    private void CaptureScreenshot()
    {
        try
        {
            if (Driver is not ITakesScreenshot screenshotDriver)
            {
                return;
            }

            var screenshotsDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Screenshots");
            Directory.CreateDirectory(screenshotsDir);

            var safeName = string.Join("_", TestContext.CurrentContext.Test.Name.Split(Path.GetInvalidFileNameChars()));
            var filePath = Path.Combine(
                screenshotsDir,
                $"{safeName}_{_browserType}_{DateTime.Now:yyyyMMdd_HHmmss}.png");

            screenshotDriver.GetScreenshot().SaveAsFile(filePath);
            Logger.Info($"Screenshot saved: {filePath}");
            TestContext.AddTestAttachment(filePath);
        }
        catch (Exception ex)
        {
            Logger.Error("Failed to capture screenshot.", ex);
        }
    }
}
