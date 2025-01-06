using Android.Util;

namespace MauiSandbox.Services;

public partial class Logger
{
	static partial void LogMessageUsingNativeLoggerInternal (string message)
	{
		Log.Info ("Test", message);
	}
}
