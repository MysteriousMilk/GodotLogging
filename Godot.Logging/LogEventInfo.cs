namespace Godot.Logging;

/// <summary>
/// Contains information about a log event.
/// </summary>
public class LogEventInfo
{
    /// <summary>
    /// The type name of the class from which the log event was triggered.
    /// </summary>
    public string ClassName
    {
        get;
        internal set;
    } = string.Empty;

    /// <summary>
    /// The method name from which the log event was triggered.
    /// </summary>
    public string MethodName
    {
        get;
        internal set;
    } = string.Empty;

    /// <summary>
    /// The message to be logged.
    /// </summary>
    public string Message
    {
        get;
        internal set;
    } = string.Empty;

    /// <summary>
    /// Default constructor.
    /// </summary>
    public LogEventInfo()
    {

    }

    /// <summary>
    /// Constructor which takes the log message.
    /// </summary>
    /// <param name="message">The message to log.</param>
    public LogEventInfo(string message)
    {
        Message = message;
    }

    /// <summary>
    /// Constructor which takes the log message, class name and method name.
    /// </summary>
    /// <param name="message">The message to log.</param>
    /// <param name="className">The name of the class from which the event originated.</param>
    /// <param name="methodName">The name of the method from which the event originated.</param>
    public LogEventInfo(string message, string className, string methodName)
    {
        Message = message;
        ClassName = className;
        MethodName = methodName;
    }
}
