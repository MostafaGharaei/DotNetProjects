using System;
using System.IO;
using System.Threading;

namespace SingletonDemo;

/// <summary>
/// Thread-safe Singleton Logger using Lazy<T> (Recommended for .NET 8)
/// </summary>
public sealed class Logger
{
    // Lazy initialization with thread safety (built-in in .NET)
    private static readonly Lazy<Logger> _instance = new(
        () => new Logger(),
        LazyThreadSafetyMode.ExecutionAndPublication);

    private readonly string _logFilePath;
    private readonly object _lockObject = new();

    /// <summary>
    /// Private constructor prevents instantiation from outside
    /// </summary>
    private Logger()
    {
        _logFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "app.log");
        Console.WriteLine($"🔧 Logger instance created at {DateTime.Now:HH:mm:ss}");
    }

    /// <summary>
    /// Public static property to access the single instance
    /// </summary>
    public static Logger Instance => _instance.Value;

    /// <summary>
    /// Logs an information message
    /// </summary>
    public void LogInfo(string message) => Log("INFO", message);

    /// <summary>
    /// Logs an error message
    /// </summary>
    public void LogError(string message) => Log("ERROR", message);

    /// <summary>
    /// Logs a warning message
    /// </summary>
    public void LogWarning(string message) => Log("WARNING", message);

    /// <summary>
    /// Logs a debug message
    /// </summary>
    public void LogDebug(string message) => Log("DEBUG", message);

    /// <summary>
    /// Internal logging method with thread safety
    /// </summary>
    private void Log(string level, string message)
    {
        lock (_lockObject)
        {
            var logEntry = $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] [{level}] {message}";
            Console.WriteLine(logEntry);

            try
            {
                File.AppendAllText(_logFilePath, logEntry + Environment.NewLine);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"⚠️ Failed to write to log file: {ex.Message}");
            }
        }
    }

    /// <summary>
    /// Clears the log file
    /// </summary>
    public void ClearLog()
    {
        lock (_lockObject)
        {
            try
            {
                File.WriteAllText(_logFilePath, string.Empty);
                Console.WriteLine("🧹 Log cleared!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"⚠️ Failed to clear log: {ex.Message}");
            }
        }
    }

    /// <summary>
    /// Gets the current log file path
    /// </summary>
    public string LogFilePath => _logFilePath;
}