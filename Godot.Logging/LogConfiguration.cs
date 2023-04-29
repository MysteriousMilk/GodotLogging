namespace Godot.Logging;

using Godot.Logging.Targets;
using System;
using System.Collections.Generic;

/// <summary>
/// Configuration for the logger.
/// </summary>
public class LogConfiguration
{
    private Dictionary<string, LogTarget> targets;
    private Dictionary<LogLevel, FormatRule> formattingRules;

    /// <summary>
    /// Rules used for formatting log entries.
    /// </summary>
    public IEnumerable<FormatRule> FormattingRules
    {
        get => formattingRules.Values;
    }

    /// <summary>
    /// Enumerates all currently registered <see cref="LogTarget"/> objects.
    /// </summary>
    public IEnumerable<LogTarget> Targets
    {
        get => targets.Values;
    }

    /// <summary>
    /// Default constructor.
    /// </summary>
    public LogConfiguration()
    {
        targets = new Dictionary<string, LogTarget>();
        formattingRules = new Dictionary<LogLevel, FormatRule>();

        FormatRule debugRule = new FormatRule()
        {
            FormatText = "[${level}][${classname}.${methodname}] ${message}",
            FormatLogLevel = LogLevel.Debug
        };
        ApplyFormattingRule(debugRule);

        FormatRule infoRule = new FormatRule()
        {
            FormatText = "[${level}][${classname}.${methodname}] ${message}",
            FormatLogLevel = LogLevel.Info
        };
        ApplyFormattingRule(infoRule);

        FormatRule cmdRule = new FormatRule()
        {
            FormatText = "${message}",
            FormatLogLevel = LogLevel.Command
        };
        ApplyFormattingRule(cmdRule);

        FormatRule warningRule = new FormatRule()
        {
            FormatText = "[${level}][${classname}.${methodname}] ${message}",
            FormatLogLevel = LogLevel.Warn,
            TextColor = Colors.Yellow
        };
        ApplyFormattingRule(warningRule);

        FormatRule errorRule = new FormatRule()
        {
            FormatText = "[${level}][${classname}.${methodname}] ${message}",
            FormatLogLevel = LogLevel.Error,
            TextColor = Colors.Red
        };
        ApplyFormattingRule(errorRule);
    }

    /// <summary>
    /// Applies a formatting rule for the <see cref="LogLevel"/> contained within
    /// the <see cref="FormatRule"/>.
    /// </summary>
    /// <remarks>This operation will overwrite any existing rule for the contained <see cref="LogLevel"/>.</remarks>
    /// <param name="rule">The rule to apply.</param>
    public void ApplyFormattingRule(FormatRule rule)
    {
        formattingRules[rule.FormatLogLevel] = rule;
    }

    /// <summary>
    /// Gets the <see cref="FormatRule"/> for the given <see cref="LogLevel"/>.
    /// </summary>
    /// <param name="logLevel">The log level for which to obtain a format for.</param>
    /// <returns>A format rule.</returns>
    public FormatRule GetFormat(LogLevel logLevel)
    {
        return formattingRules[logLevel];
    }

    /// <summary>
    /// Gets a <see cref="LogTarget"/> by name.
    /// </summary>
    /// <param name="targetName">The name of the target to find.</param>
    /// <returns>A <see cref="LogTarget"/> referenced by the given name, or null if not found.</returns>
    public LogTarget GetTarget(string targetName)
    {
        if (!targets.ContainsKey(targetName))
            return null;

        return targets[targetName];
    }

    /// <summary>
    /// Gets the first <see cref="LogTarget"/> of a given type.
    /// </summary>
    /// <typeparam name="T">The derived <see cref="LogTarget"/> type.</typeparam>
    /// <returns>A <see cref="LogTarget"/> of the specified derived type, or null if not found.</returns>
    public T GetTarget<T>() where T : LogTarget
    {
        T targetToFind = default;
        Type typeToFind = typeof(T);

        foreach (var target in Targets)
        {
            if (typeToFind.Equals(target.GetType()))
            {
                targetToFind = (T)target;
                break;
            }
        }

        return targetToFind;
    }

    /// <summary>
    /// Registers a <see cref="LogTarget"/> with the <see cref="LogConfiguration"/>.
    /// </summary>
    /// <param name="target">The <see cref="LogTarget"/> to register.</param>
    public void RegisterTarget(LogTarget target)
    {
        if (targets.ContainsKey(target.Name))
            throw new InvalidOperationException("LogTarget by the name of " + target.Name + " has already been registered with this configuration.");

        target.SetConfiguration(this);
        targets.Add(target.Name, target);
    }
}
