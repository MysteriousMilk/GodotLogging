# Godot Logging Library
[![NuGet version (Godot.Logging)](https://img.shields.io/badge/nuget-v1.2-blue?style=flat-square)](https://www.nuget.org/packages/Godot.Logging/1.2/)\
[![NuGet version (Godot.Logging)](https://img.shields.io/badge/nuget-v1.1.4-blue?style=flat-square)](https://www.nuget.org/packages/Godot.Logging/1.1.4/)

A C# logging library for the Godot game engine. The library provides several Log Targets needed to log messages in a variety of formats. This is intended to work with the .NET version of Godot (C#). The latest NuGet packages provide targets for .NET 6, .NET 7, and .NET 8.

## Version Compatibility
Different versions of Godot.Logging may support different version of the Godot SDK. See below.

**Godot.Logging v1.2.\*** -> Godot SDK 4.2.2 or greater\
**Godot.Logging v1.1.\*** -> Godot SDK 4.0.2 or greater

## Usage
#### Overview
Logging can be configured for use in just a few lines of code.
```C#
// Create a configuration for the logger
LogConfiguration config = new LogConfiguration();
config.RegisterTarget(new GDPrintTarget("GodotConsole"));

// Set the configuration
GodotLogger.SetConfiguration(config);

// Start logging messages!
GodotLogger.LogInfo("Hello Godot!");
```

#### Logging Exceptions
Exceptions may be logged as well.
```C#
try
{
    throw new Exception(exMsg);
}
catch (Exception ex)
{
    GodotLogger.LogException(ex, "An exception occurred.");
}
```

When logging excpetions, if preferred, the whole stack trace can be outputted in the log with the following setting.
```C#
GodotLogger.Instance.Configuration.IncludeExceptionCallStack = true;
```

#### Format Rules
Formatting rules (output format in the log) may be specified. In the LogConfiguration, you may specify 1 format rule per log level.

```C#
FormatRule infoRule = new FormatRule()
{
    FormatText = "[${level}][${classname}.${methodname}] ${message}",
    FormatLogLevel = LogLevel.Info
};
GodotLogger.Instance.Configuration.ApplyFormattingRule(infoRule);
```
As seen above, format rules may include macros to indicate parts of the format to be replace with log entry specific information. Here are the current macros that are supported.

**\${level}** - Log level associated with the log entry.\
**\${classname}** - Class or type name of the object from where the log entry was invoked.\
**\${methodname}** - Name of the method within the object from where the log entry was invoked.\
**\${message}** - The actual message recorded for the log entry / event.