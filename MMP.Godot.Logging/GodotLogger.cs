using Godot;
using System.Diagnostics;

namespace MMP.Godot.Logging
{
    /// <summary>
    /// The logger singleton. Used to record log
    /// entries to the game's log.
    /// </summary>
    public sealed class GodotLogger
    {
        #region Singleton Instance
        private static readonly GodotLogger instance = new GodotLogger();

        static GodotLogger()
        {
        }

        private GodotLogger()
        {
        }

        public static GodotLogger Instance
        {
            get => instance;
        }
        #endregion

        #region Static API
        /// <summary>
        /// Sets the configuration for the <see cref="GodotLogger"/>.
        /// </summary>
        /// <param name="config">The log configuration.</param>
        public static void SetConfiguration(LogConfiguration config)
        {
            Instance.Configuration = config;
        }

        /// <summary>
        /// Logs a debug message.
        /// </summary>
        /// <param name="message">The debug message to log.</param>
        public static void LogDebug(object message)
        {
#if DEBUG
            Instance.Log(LogLevel.Debug, message);
#endif
        }

        /// <summary>
        /// Logs an informative message.
        /// </summary>
        /// <param name="message">The message to log.</param>
        public static void LogInfo(object message)
        {
            Instance.Log(LogLevel.Info, message);
        }

        /// <summary>
        /// Logs a command message. Typically used to echo user-entered commands
        /// from a game's command line console.
        /// </summary>
        /// <param name="message">The command message.</param>
        public static void LogCommand(object message)
        {
            Instance.Log(LogLevel.Command, message);
        }

        /// <summary>
        /// Logs a warning message.
        /// </summary>
        /// <param name="message">The warning message to log.</param>
        public static void LogWarning(object message)
        {
            Instance.Log(LogLevel.Warn, message);
        }

        /// <summary>
        /// Logs an error message.
        /// </summary>
        /// <param name="message">The error message to log.</param>
        public static void LogError(object message)
        {
            Instance.Log(LogLevel.Error, message);
        }
        #endregion

        /// <summary>
        /// The configuration used by the logger.
        /// </summary>
        public LogConfiguration Configuration
        {
            get;
            set;
        }

        /// <summary>
        /// Adds an entry to the log at the given <see cref="LogLevel"/>.
        /// </summary>
        /// <param name="logLevel">Log level to record the entry at.</param>
        /// <param name="message">The log entry message.</param>
        public void Log(LogLevel logLevel, object message)
        {
            var logEvent = CreateLogEvent();
            logEvent.Message = message.ToString();

            foreach (var target in Configuration.Targets)
                target.Write(logLevel, logEvent);

            if (logLevel == LogLevel.Error)
                GD.PushError(logEvent.Message);
        }

        /// <summary>
        /// Creates a <see cref="LogEventInfo"/> using the current call stack.
        /// </summary>
        /// <returns>An initialized <see cref="LogEventInfo"/> without the message.</returns>
        private LogEventInfo CreateLogEvent()
        {
            LogEventInfo logEvent = new LogEventInfo();

            for (int frameIndex = 1; frameIndex <= 5; frameIndex++)
            {
                var frame = new StackFrame(frameIndex);
                var method = frame.GetMethod();
                var declaringType = method.DeclaringType;

                if (declaringType != typeof(GodotLogger))
                {
                    logEvent.MethodName = method.Name;
                    logEvent.ClassName = declaringType.Name;
                    break;
                }
            }

            return logEvent;
        }
    }
}
