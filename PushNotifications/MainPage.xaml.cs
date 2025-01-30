using Plugin.Firebase.CloudMessaging;

namespace PushNotifications;

public partial class MainPage : ContentPage
{
	int count = 0;

	public MainPage()
	{
		InitializeComponent();
	}

	private void OnCounterClicked(object sender, EventArgs e)
	{
		count++;

		if (count == 1)
			CounterBtn.Text = $"Clicked {count} time";
		else
			CounterBtn.Text = $"Clicked {count} times";

		SemanticScreenReader.Announce(CounterBtn.Text);
	}

    private async void Button_Clicked(object sender, EventArgs e)
    {
		PermissionStatus permissionStatus = await Permissions.CheckStatusAsync<Permissions.PostNotifications>();

		if (permissionStatus != PermissionStatus.Granted)
		{
			permissionStatus = await Permissions.RequestAsync<Permissions.PostNotifications>();

			if (permissionStatus != PermissionStatus.Granted)
			{
				return;
			}
		}

		await CrossFirebaseCloudMessaging.Current.CheckIfValidAsync();
		var token = await CrossFirebaseCloudMessaging.Current.GetTokenAsync();

		await Share.RequestAsync(new ShareTextRequest
		{
			Text = token,
			Title = "Share Firebase Token"
		});
    }
}

