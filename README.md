# Godot Logging Library
[![NuGet version (Godot.Logging)](https://img.shields.io/badge/nuget-v1.1.1-blue?style=flat-square)](https://www.nuget.org/packages/Godot.Logging/1.1.1/)

A C# logging library for the Godot game engine. The library provides several Log Targets needed to log messages in a variety of formats. This is intended to work with the Mono version of Godot (C#). Just drop the code in with your main project and you can start logging messages right away.

## Repository
The main branch [*origin/main*] will be kept in line with the latest release of Godot. Currently it is syncing with the latest Godot 4 beta. There is a release for the Godot 3.5.x line.

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
