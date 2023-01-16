namespace Godot.Logging.Targets
{
    public class FileTarget : LogTarget
    {
        private FileAccess file;
        private string filename;

        /// <summary>
        /// The filename of the file to write teh log contents to.
        /// </summary>
        public string FileName => filename;

        /// <summary>
        /// Default Constructor.
        /// </summary>
        /// <param name="name">The name of the <see cref="LogTarget"/>.</param>
        /// <param name="filename">The filename of the file to write the log contents to.</param>
        public FileTarget(string name, string filename) : base(name)
        {
            this.filename = filename;

            file = FileAccess.Open(filename, FileAccess.ModeFlags.Write);
        }

        /// <summary>
        /// Writes a log event to the <see cref="LogTarget"/>.
        /// </summary>
        /// <param name="logLevel">The level/severity of the log event.</param>
        /// <param name="logEvent">The log event.</param>
        public override void Write(LogLevel logLevel, LogEventInfo logEvent)
        {
            string outputText = FormatLogText(logLevel, logEvent);

            file.StoreLine(outputText);
        }
    }
}
