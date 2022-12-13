using System.Text;

namespace Godot.Logging
{
    public static class ColorExtensions
    {
        public static string ToHexArgb(this Color color)
        {
            var builder = new StringBuilder();
            builder.Append("#");
            builder.Append(color.a8.ToString("X2"));
            builder.Append(color.r8.ToString("X2"));
            builder.Append(color.g8.ToString("X2"));
            builder.Append(color.b8.ToString("X2"));
            return builder.ToString();
        }
    }

    public partial class FormatRule
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
