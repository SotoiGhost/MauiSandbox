using Android.App;
using Android.Content;

using AndroidX.Core.App;

using Firebase.Messaging;

using Plugin.Firebase.CloudMessaging;

namespace PushNotifications;

[Service (Name = "com.turtlebeach.XEFAH.iOS.MyFirebaseMessagingService", Exported = false)]
[IntentFilter (["com.google.firebase.MESSAGING_EVENT"])]
public class MyFirebaseMessagingService : FirebaseMessagingService {
	public override void OnMessageReceived (RemoteMessage message)
	{
		Console.WriteLine ($"{nameof (OnMessageReceived)} From: {message.From}");

		base.OnMessageReceived (message);

		if (message.GetNotification () is not null) {
			return;
		}

		if (message.Data is IDictionary<string, string> data) {
			var intent = new Intent (this, typeof (MainActivity))
				.SetFlags (ActivityFlags.SingleTop);

			var pendingIntent = PendingIntent.GetActivity (this, 0, intent, PendingIntentFlags.Immutable);

			// It dismiss the notification, but does not open the browser if the app is in background
			// var acceptIntent = new Intent (this, typeof (MyBroadcastReceiver))
			// 	.SetAction ("OPEN_ACTION")
			// 	.PutExtra ("action_message", "OUCH!");
			// var acceptBroadcastPendingIntent = PendingIntent.GetBroadcast (this, 0, acceptIntent, PendingIntentFlags.Immutable);

			// It opens the browser, but does not dismiss the notification
			// var acceptIntent = new Intent (Intent.ActionView)
			// 	.SetFlags (ActivityFlags.NewTask)
			// 	.SetData (Android.Net.Uri.Parse ("https://www.turtlebeach.com/"))
			// var acceptBroadcastPendingIntent = PendingIntent.GetActivity (this, 0, acceptIntent, PendingIntentFlags.Immutable);

			var acceptIntent = new Intent (this, typeof (MainActivity))
				.SetFlags (ActivityFlags.SingleTop)
				.SetAction ("OPEN_ACTION");
			var acceptBroadcastPendingIntent = PendingIntent.GetActivity (this, 0, acceptIntent, PendingIntentFlags.Immutable);

			var declineIntent = new Intent (this, typeof (MyBroadcastReceiver))
				.SetAction ("DECLINE_ACTION")
				.PutExtra ("action_message", "...");
			var declineBroadcastPendingIntent = PendingIntent.GetBroadcast (this, 1, declineIntent, PendingIntentFlags.Immutable);

			var channelId = FirebaseCloudMessagingImplementation.ChannelId;

			Notification notification = new NotificationCompat.Builder (this, channelId)
				.SetContentTitle (data ["title"])
				.SetContentText (data ["body"])
				.SetSmallIcon (Resource.Drawable.notification_template_icon_bg)
				.SetPriority (NotificationCompat.PriorityDefault)
				.SetContentIntent (pendingIntent)
				.SetAutoCancel (true)
				.AddAction (Resource.Drawable.ic_call_answer, "Open TB Website", acceptBroadcastPendingIntent)
				.AddAction (Resource.Drawable.ic_call_decline, "Decline", declineBroadcastPendingIntent)
				.Build ();

			NotificationManagerCompat notificationManager = NotificationManagerCompat.From (this);
			notificationManager.Notify (0, notification);
		}
	}

	public override void OnDeletedMessages ()
	{
		Console.WriteLine (nameof (OnDeletedMessages));

		base.OnDeletedMessages ();
	}
}

[BroadcastReceiver (Name = "com.turtlebeach.XEFAH.iOS.MyBroadcastReceiver", Exported = false)]
public class MyBroadcastReceiver : BroadcastReceiver {
	public override void OnReceive (Context? context, Intent? intent)
	{
		Console.WriteLine ($"{nameof (OnReceive)} Action: {intent?.Action}");

		NotificationManagerCompat notificationManager = NotificationManagerCompat.From (context!);
		// Dismiss the notification
		notificationManager.Cancel (0);

		if (intent?.Action == "DECLINE_ACTION")
			return;
	}
}
