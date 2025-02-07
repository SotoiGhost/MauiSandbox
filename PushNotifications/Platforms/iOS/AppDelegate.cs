using Foundation;
using UIKit;
using UserNotifications;

namespace PushNotifications;

[Register("AppDelegate")]
public class AppDelegate : MauiUIApplicationDelegate
{
	protected override MauiApp CreateMauiApp()
	{
		return MauiProgram.CreateMauiApp();
	}
}

public class NotificationCenterDelegate : UNUserNotificationCenterDelegate
{
	public override void WillPresentNotification(UNUserNotificationCenter center, UNNotification notification, Action<UNNotificationPresentationOptions> completionHandler)
	{
		Console.WriteLine(nameof(WillPresentNotification));
		Console.WriteLine(notification.Request.Content.Title);
		Console.WriteLine(notification.Request.Content.Body);

		completionHandler(UNNotificationPresentationOptions.Badge | UNNotificationPresentationOptions.Sound | UNNotificationPresentationOptions.Banner);
	}

	public override void DidReceiveNotificationResponse(UNUserNotificationCenter center, UNNotificationResponse response, Action completionHandler)
	{
		Console.WriteLine(nameof(DidReceiveNotificationResponse));
		Console.WriteLine(response.Notification.Request.Content.Title);
		Console.WriteLine(response.Notification.Request.Content.Body);

		if (response.Notification.Request.Content.CategoryIdentifier == "NOTIFICATION_WITH_ACTIONS")
		{
			if (response.IsCustomAction) {
				switch (response.ActionIdentifier) {
				case "ACCEPT_ACTION":
					Console.WriteLine ("Accept action tapped");
					UIApplication.SharedApplication.OpenUrl (
						new NSUrl ("https://www.turtlebeach.com/"),
						new UIApplicationOpenUrlOptions(),
						null);
					break;
				case "DECLINE_ACTION":
					Console.WriteLine ("Decline action tapped");
					break;
				default:
					Console.WriteLine ("Unknown action tapped");
					break;
				}
			}
			else if (response.IsDefaultAction)
			{
				Console.WriteLine ("Default action tapped");
			}
			else
			{
				Console.WriteLine ("Dismiss action tapped");
			}
		}

		completionHandler();
	}
}
