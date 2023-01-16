using System.Text;

namespace Godot.Logging.Targets
{
    public class BBTextTarget : MemoryTarget
    {
        /// <summary>
        /// Default constructor for a <see cref="BBTextTarget"/>.
        /// </summary>
        /// <param name="name">The name to give the target within the logging system.</param>
        public BBTextTarget(string name) : base(name)
        {
        }

        /// <summary>
        /// Constructor for a <see cref="BBTextTarget"/> that allows setting
        /// the size of the buffer (in lines).
        /// </summary>
        /// <param name="name">The name to give the target within the logging system.</param>
        /// <param name="bufferSize">The number log entries to be kept in memory.</param>
        public BBTextTarget(string name, int bufferSize) : base(name)
        {
        }

        /// <summary>
        /// Writes a log event to the <see cref="LogTarget"/>.
        /// </summary>
        /// <param name="logLevel">The level/severity of the log event.</param>
        /// <param name="logEvent">The log event.</param>
        public override void Write(LogLevel logLevel, LogEventInfo logEvent)
        {
            base.Write(logLevel, logEvent);

            var format = config.GetFormat(logLevel);

            var builder = new StringBuilder();
            builder.Append("[color=");
            builder.Append(format.TextColor.ToHexArgb());
            builder.Append("]");
            builder.Append(lineBuffer.Last.Value);
            builder.Append("[/color]");

            lineBuffer.Last.Value = builder.ToString();
        }
    }
}
