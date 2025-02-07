using Foundation;

using Microsoft.Maui.LifecycleEvents;

using Plugin.Firebase.CloudMessaging;
using Plugin.Firebase.Core.Platforms.iOS;
using UserNotifications;

namespace PushNotifications;

public static partial class MauiProgram
{
    private static partial MauiAppBuilder RegisterFirebaseServices(this MauiAppBuilder builder)
    {
        builder.ConfigureLifecycleEvents(events => {
            events.AddiOS(iOS => { 
                iOS.WillFinishLaunching((_, __) => {
                    CrossFirebase.Initialize();
                    FirebaseCloudMessagingImplementation.Initialize();
                    return true;
                });

                iOS.FinishedLaunching((_, __) => {
					var userNotificationCenter = UNUserNotificationCenter.Current;
                    userNotificationCenter.Delegate = new NotificationCenterDelegate();

					var acceptAction = UNNotificationAction.FromIdentifier("ACCEPT_ACTION", "Open TB Website", UNNotificationActionOptions.Foreground);
					var declineAction = UNNotificationAction.FromIdentifier("DECLINE_ACTION", "Decline", UNNotificationActionOptions.None);

					var notificationWithActions = UNNotificationCategory.FromIdentifier("NOTIFICATION_WITH_ACTIONS", [acceptAction, declineAction], [], UNNotificationCategoryOptions.CustomDismissAction);

					userNotificationCenter.SetNotificationCategories(new NSSet<UNNotificationCategory>(notificationWithActions));

                    return true;
                });
            });
        });
        
        return builder;
    }
}
