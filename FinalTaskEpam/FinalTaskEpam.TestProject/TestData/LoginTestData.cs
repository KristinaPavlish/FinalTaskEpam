namespace FinalTaskEpam.TestProject.TestData;

public static class LoginTestData
{
    /// <summary>
    /// Test data for UC-1 (empty password validation).
    /// Any username should display the same validation error.
    /// </summary>
    public static IEnumerable<string> Usernames()
    {
        yield return TestUsers.StandardUser;
        yield return TestUsers.LockedOutUser;
        yield return TestUsers.ProblemUser;
        yield return TestUsers.PerformanceGlitchUser;
        yield return TestUsers.ErrorUser;
        yield return TestUsers.VisualUser;
    }

    /// <summary>
    /// Test data for UC-2 (login with valid credentials).
    /// </summary>
    public static IEnumerable<LoginTestCase> ValidUsers()
    {
        yield return new LoginTestCase
        {
            Username = TestUsers.StandardUser,
            Password = TestUsers.Password,
            ShouldSucceed = true
        };
    }
}
