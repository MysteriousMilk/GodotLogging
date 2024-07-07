namespace Godot.Logging.Targets;

using System.Collections.Generic;

/// <summary>
/// Base class for a log target.
/// </summary>
public abstract class LogTarget
{
    protected List<LogLevel> supportedLevels;
    protected LogConfiguration config;

    /// <summary>
    /// The name of the <see cref="LogTarget"/>.
    /// </summary>
    public string Name
    {
        get;
        private set;
    }

    /// <summary>
    /// Default constructor for <see cref="LogTarget"/>.
    /// </summary>
    public LogTarget(string name)
    {
        supportedLevels = new List<LogLevel>();
        Name = name;
    }

    /// <summary>
    /// Writes a log event to the <see cref="LogTarget"/>.
    /// </summary>
    /// <param name="logLevel">The level/severity of the log event.</param>
    /// <param name="logEvent">The log event.</param>
    public abstract void Write(LogLevel logLevel, LogEventInfo logEvent);

    /// <summary>
    /// Formats the log text based on <see cref="FormatRule"/> associated with the <see cref="LogConfiguration"/>.
    /// </summary>
    /// <param name="logLevel">The level/severity of the log event.</param>
    /// <param name="logEvent">The log event.</param>
    /// <returns>A formatted string.</returns>
    protected string FormatLogText(LogLevel logLevel, LogEventInfo logEvent)
    {
        var format = config.GetFormat(logLevel);

        string output = (string)format.FormatText.Clone();
        output = output.Replace("${level}", logLevel.ToString());
        output = output.Replace("${classname}", logEvent.ClassName);
        output = output.Replace("${methodname}", logEvent.MethodName);
        output = output.Replace("${message}", logEvent.Message);
        return output;
    }

    /// <summary>
    /// Passes the <see cref="LogConfiguration"/> to the <see cref="LogTarget"/>.
    /// </summary>
    /// <param name="cfg">The LogConfiguration.</param>
    internal void SetConfiguration(LogConfiguration cfg)
    {
        config = cfg;
    }

    /// <summary>
    /// Clears the log information associated with this <see cref="LogTarget"/>.
    /// </summary>
    internal abstract void Clear();
}
