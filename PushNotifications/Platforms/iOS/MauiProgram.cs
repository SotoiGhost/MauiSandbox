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
                    return false;
                });

                iOS.FinishedLaunching((_, __) => {
		            UNUserNotificationCenter.Current.Delegate = new NotificationCenterDelegate();
                    return false;
                });
            });
        });
        
        return builder;
    }
}
