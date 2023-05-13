using Godot;
using System.Text;

namespace MMP.Godot.Logging
{
    /// <summary>
    /// Extension methods for <see cref="Color"/> struct.
    /// </summary>
    public static class ColorExtensions
    {
        /// <summary>
        /// Converts a <see cref="Color"/> to a color hexidecimal string.
        /// </summary>
        /// <param name="color">The color object.</param>
        /// <returns>Hexidecimal string.</returns>
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
    }

    /// <summary>
    /// Class that describes how to format a log entry.
    /// </summary>
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
}
