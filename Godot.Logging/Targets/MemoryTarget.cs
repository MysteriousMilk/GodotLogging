using System.Collections.Generic;
using System.Text;

namespace Godot.Logging.Targets
{
    /// <summary>
    /// In-memory log target.
    /// </summary>
    public class MemoryTarget : LogTarget
    {
        protected LinkedList<string> lineBuffer;
        protected int maxLineCount;

        /// <summary>
        /// Default constructor for a <see cref="MemoryTarget"/>.
        /// </summary>
        /// <param name="name">The name to give the target within the logging system.</param>
        public MemoryTarget(string name) : base(name)
        {
            lineBuffer = new LinkedList<string>();
            maxLineCount = int.MaxValue;
        }

        /// <summary>
        /// Constructor for a <see cref="MemoryTarget"/> that allows setting
        /// the size of the buffer (in lines).
        /// </summary>
        /// <param name="name">The name to give the target within the logging system.</param>
        /// <param name="bufferSize">The number log entries to be kept in memory.</param>
        public MemoryTarget(string name, int bufferSize) : this(name)
        {
            maxLineCount = bufferSize;
        }

        /// <summary>
        /// Writes a log event to the <see cref="LogTarget"/>.
        /// </summary>
        /// <param name="logLevel">The level/severity of the log event.</param>
        /// <param name="logEvent">The log event.</param>
        public override void Write(LogLevel logLevel, LogEventInfo logEvent)
        {
            string outputText = FormatLogText(logLevel, logEvent);

            if (lineBuffer.Count == maxLineCount)
                lineBuffer.RemoveFirst();

            lineBuffer.AddLast(outputText);
        }

        /// <summary>
        /// Returns the entire log as a string.
        /// </summary>
        /// <returns>The log as a string.</returns>
        public override string ToString()
        {
            var builder = new StringBuilder();
            foreach (var line in lineBuffer)
                builder.AppendLine(line);
            return builder.ToString();
        }
    }
}
