using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;

using AndroidX.Core.App;

using Plugin.Firebase.CloudMessaging;

namespace PushNotifications;

[Activity(Theme = "@style/Maui.SplashTheme", MainLauncher = true, LaunchMode = LaunchMode.SingleTop, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize | ConfigChanges.Density)]
public class MainActivity : MauiAppCompatActivity
{
    protected override void OnCreate(Bundle? savedInstanceState)
    {
        base.OnCreate(savedInstanceState);
        HandleIntent(Intent);
        CreateNotificationChannelIfNeeded();
    }

    protected override void OnNewIntent(Intent? intent)
    {
        base.OnNewIntent(intent);
        HandleIntent(intent);
    }

    private void HandleIntent(Intent? intent)
    {
		if (intent?.Action == "OPEN_ACTION") {
			NotificationManagerCompat.From (this).Cancel (0);
			var acceptIntent = new Intent (Intent.ActionView)
				.SetFlags (ActivityFlags.NewTask | ActivityFlags.FromBackground)
				.SetData (Android.Net.Uri.Parse ("https://www.turtlebeach.com/"));
			StartActivity (acceptIntent);
		} else {
			FirebaseCloudMessagingImplementation.OnNewIntent (intent);
		}
    }

    private void CreateNotificationChannelIfNeeded()
    {
        if (Build.VERSION.SdkInt >= BuildVersionCodes.O &&
            GetSystemService(NotificationService) is NotificationManager notificationManager)
        {
            var channelId = $"{PackageName}.general";
            var channel = new NotificationChannel(channelId, "General", NotificationImportance.Default);
            notificationManager.CreateNotificationChannel(channel);
            FirebaseCloudMessagingImplementation.ChannelId = channelId;
        }
    }
}
