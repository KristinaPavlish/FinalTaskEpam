namespace FinalTaskEpam.TestProject.TestData;

public class LoginTestCase
{
    public string Username { get; set; } = string.Empty;

    public string Password { get; set; } = string.Empty;

    public bool ShouldSucceed { get; set; }

    public string ExpectedError { get; set; } = string.Empty;

    public override string ToString()
    {
        return Username;
    }
}