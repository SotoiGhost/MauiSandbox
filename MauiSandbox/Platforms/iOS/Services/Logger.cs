using System.Runtime.InteropServices;

using Foundation;

namespace MauiSandbox.Services;

public partial class Logger
{
	[LibraryImport(ObjCRuntime.Constants.FoundationLibrary)]
	private static partial void NSLog(IntPtr message);
	
	static partial void LogMessageUsingNativeLoggerInternal (string message)
	{
		NSLog(new NSString(message).Handle);
	}
}
