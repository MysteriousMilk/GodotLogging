# Godot Logging Library
[![NuGet version (Godot.Logging)](https://img.shields.io/badge/nuget-v1.1.3-blue?style=flat-square)](https://www.nuget.org/packages/Godot.Logging/1.1.3/)

A C# logging library for the Godot game engine. The library provides several Log Targets needed to log messages in a variety of formats. This is intended to work with the Mono version of Godot (C#). Just drop the code in with your main project and you can start logging messages right away.

## Usage
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
