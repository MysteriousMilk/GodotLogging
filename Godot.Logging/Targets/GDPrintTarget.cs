namespace Godot.Logging.Targets;

using Godot;

/// <summary>
/// A <see cref="LogTarget"/> that uses the GD.Print methods
/// as a log output source.
/// </summary>
public class GDPrintTarget : LogTarget
{
    /// <summary>
    /// Default constructor for a <see cref="GDPrintTarget"/>.
    /// </summary>
    /// <param name="name">The name to give the target within the logging system.</param>
    public GDPrintTarget(string name) : base(name)
    {

    }

    /// <summary>
    /// Writes a log event to the <see cref="LogTarget"/>.
    /// </summary>
    /// <param name="logLevel">The level/severity of the log event.</param>
    /// <param name="logEvent">The log event.</param>
    public override void Write(LogLevel logLevel, LogEventInfo logEvent)
    {
        string outputText = FormatLogText(logLevel, logEvent);

        switch (logLevel)
        {
            case LogLevel.Debug:
            case LogLevel.Info:
            case LogLevel.Command:
                GD.Print(outputText);
                break;
            case LogLevel.Warn:
                GD.Print(outputText);
                GD.PushWarning(outputText);
                break;
            case LogLevel.Error:
                GD.Print(outputText);
                GD.PrintErr(outputText);
                break;
        }
    }

    internal override void Clear()
    {
        // Not possible to clear the Godot log written with GD.Print. So, do nothing.
    }
}
