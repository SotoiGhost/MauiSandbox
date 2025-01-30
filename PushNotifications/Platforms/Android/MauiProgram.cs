using Microsoft.Maui.LifecycleEvents;

using Plugin.Firebase.Core.Platforms.Android;

namespace PushNotifications;

public static partial class MauiProgram
{
	private static partial MauiAppBuilder RegisterFirebaseServices(this MauiAppBuilder builder)
    {
        builder.ConfigureLifecycleEvents(events => {
            events.AddAndroid(android => android.OnCreate((activity, _) =>
                CrossFirebase.Initialize(activity)));
        });
        
        return builder;
    }
}
