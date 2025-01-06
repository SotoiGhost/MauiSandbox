using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace MauiSandbox.Services;

public partial class Logger
{
	public static void LogMessageUsingConsole (string message = "", [CallerFilePath] string filePath = "", [CallerMemberName] string methodName = "", [CallerLineNumber] int line = 0)
	{
		var formattedMessage = GetFormattedMessage (message, filePath, methodName, line);
		Console.WriteLine (formattedMessage);
	}

	public static void LogMessageUsingDiagnosticsDebug (string message = "", [CallerFilePath] string filePath = "", [CallerMemberName] string methodName = "", [CallerLineNumber] int line = 0)
	{
		var formattedMessage = GetFormattedMessage (message, filePath, methodName, line);
		Debug.WriteLine (formattedMessage);
	}

	public static void LogMessageUsingNativeLogger (string message = "", [CallerFilePath] string filePath = "", [CallerMemberName] string methodName = "", [CallerLineNumber] int line = 0)
	{
		var formattedMessage = GetFormattedMessage (message, filePath, methodName, line);
		LogMessageUsingNativeLoggerInternal (formattedMessage);
	}

	static partial void LogMessageUsingNativeLoggerInternal (string message);

	static string GetFormattedMessage (string message, string filePath, string methodName, int line)
	{
		var fileName = Path.GetFileName (filePath);

		var stackFrame = new StackFrame(1);
		var className = stackFrame.GetMethod ()?.DeclaringType?.Name ?? "";

		return $"{fileName} [{className}.{methodName}:{line}] {message}";
	}
}
