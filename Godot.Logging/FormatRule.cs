namespace Godot.Logging;

using System.Text;

public static class ColorExtensions
{
    public static string ToHexArgb(this Color color)
    {
        var builder = new StringBuilder();
        builder.Append("#");
        builder.Append(color.A8.ToString("X2"));
        builder.Append(color.R8.ToString("X2"));
        builder.Append(color.G8.ToString("X2"));
        builder.Append(color.B8.ToString("X2"));
        return builder.ToString();
    }

    public static string ToHexRgb(this Color color)
    {
        var builder = new StringBuilder();
        builder.Append("#");
        builder.Append(color.R8.ToString("X2"));
        builder.Append(color.G8.ToString("X2"));
        builder.Append(color.B8.ToString("X2"));
        return builder.ToString();
    }
}

public class FormatRule
{
    /// <summary>
    /// Color to associate with the log event if the target supports color.
    /// </summary>
    public Color TextColor
    {
        get;
        set;
    } = Colors.White;

    /// <summary>
    /// Text code indicating the format to use to write the log event.
    /// </summary>
    public string FormatText
    {
        get;
        set;
    }

    /// <summary>
    /// Log level to associate the Format Rule with.
    /// </summary>
    public LogLevel FormatLogLevel
    {
        get;
        set;
    }

    /// <summary>
    ///  Default constructor.
    /// </summary>
    public FormatRule()
    {
    }
}
