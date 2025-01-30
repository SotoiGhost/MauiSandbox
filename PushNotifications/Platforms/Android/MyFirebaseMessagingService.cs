using Android.App;
using Android.Runtime;
using Firebase.Messaging;

namespace PushNotifications;

[Service(Name = "com.turtlebeach.XEFAH.iOS.MyFirebaseMessagingService", Exported = false)]
[IntentFilter(new[] { "com.google.firebase.MESSAGING_EVENT" })]
public class MyFirebaseMessagingService : FirebaseMessagingService
{
    public override void OnMessageReceived(RemoteMessage message)
    {
        base.OnMessageReceived(message);

        if (message.GetNotification() is RemoteMessage.Notification notification)
        {
            var title = notification.Title;
            var body = notification.Body;

            Console.WriteLine($"Title: {title}");
            Console.WriteLine($"Body: {body}");
            // Handle notification message
        }
    }
}
 