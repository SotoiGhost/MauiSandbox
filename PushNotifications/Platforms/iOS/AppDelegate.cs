using Foundation;
using UIKit;
using UserNotifications;

namespace PushNotifications;

[Register("AppDelegate")]
public class AppDelegate : MauiUIApplicationDelegate, IUNUserNotificationCenterDelegate
{
	protected override MauiApp CreateMauiApp()
	{
		return MauiProgram.CreateMauiApp();
	}

	// [Export("userNotificationCenter:willPresentNotification:withCompletionHandler:")]
	// public void WillPresentNotification(UNUserNotificationCenter center, UNNotification notification, Action<UNNotificationPresentationOptions> completionHandler)
	// {
	// 	Console.WriteLine(nameof(WillPresentNotification));
	// 	Console.WriteLine(notification.Request.Content.Title);
	// 	Console.WriteLine(notification.Request.Content.Body);

	// 	completionHandler(UNNotificationPresentationOptions.Badge | UNNotificationPresentationOptions.Banner);
	// }

	// [Export("userNotificationCenter:didReceiveNotificationResponse:withCompletionHandler:")]
	// public void DidReceiveNotificationResponse(UNUserNotificationCenter center, UNNotificationResponse response, Action completionHandler)
	// {
	// 	Console.WriteLine(nameof(DidReceiveNotificationResponse));
	// 	Console.WriteLine(response.Notification.Request.Content.Title);
	// 	Console.WriteLine(response.Notification.Request.Content.Body);

	// 	completionHandler();
	// }
}

public class NotificationCenterDelegate : UNUserNotificationCenterDelegate
{
	public override void WillPresentNotification(UNUserNotificationCenter center, UNNotification notification, Action<UNNotificationPresentationOptions> completionHandler)
	{
		Console.WriteLine(nameof(WillPresentNotification));
		Console.WriteLine(notification.Request.Content.Title);
		Console.WriteLine(notification.Request.Content.Body);

		completionHandler(UNNotificationPresentationOptions.Badge | UNNotificationPresentationOptions.Banner);
	}

	public override void DidReceiveNotificationResponse(UNUserNotificationCenter center, UNNotificationResponse response, Action completionHandler)
	{
		Console.WriteLine(nameof(DidReceiveNotificationResponse));
		Console.WriteLine(response.Notification.Request.Content.Title);
		Console.WriteLine(response.Notification.Request.Content.Body);

		completionHandler();
	}
}
