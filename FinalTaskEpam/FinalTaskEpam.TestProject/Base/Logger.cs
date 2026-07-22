using System.Reflection;
using log4net;
using log4net.Config;

namespace FinalTaskEpam.TestProject.Base;

/// <summary>
/// Thin facade over log4net used across the test project.
/// </summary>
public static class Logger
{
    private static readonly ILog Log;

    static Logger()
    {
        var repository = LogManager.GetRepository(Assembly.GetExecutingAssembly());
        var configFile = new FileInfo(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "log4net.config"));
        XmlConfigurator.Configure(repository, configFile);
        Log = LogManager.GetLogger(typeof(Logger));
    }

    /// <summary>
    /// Writes an informational message to the log.
    /// </summary>
    public static void Info(string message) => Log.Info(message);

    /// <summary>
    /// Writes an error message to the log.
    /// </summary>
    public static void Error(string message) => Log.Error(message);

    /// <summary>
    /// Writes an error message with exception details to the log.
    /// </summary>
    public static void Error(string message, Exception exception) => Log.Error(message, exception);
}
