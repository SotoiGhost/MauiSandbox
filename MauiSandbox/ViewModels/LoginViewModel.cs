using System;

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace MauiSandbox.ViewModels;

public partial class LoginViewModel : BaseViewModel {
	[ObservableProperty]
	string? username;

	[ObservableProperty]
	string? password;

	[RelayCommand]
	async Task Login ()
	{
		if (string.IsNullOrWhiteSpace (Username) || string.IsNullOrWhiteSpace (Password)) {
			await DisplayLoginError ();
			return;
		}

		// Call API to attempt a login
		var loginSuccessful = true;

		if (loginSuccessful) {
			// Display a welcome message
			// Build a menu on the fly... based on the user role
			// Navigate to the app's main page
		}
	}

	async Task DisplayLoginError ()
	{
		// Display an error message to the user
		await Shell.Current.DisplayAlert ("Login Error", "Invalid username or password.", "OK");
		Password = string.Empty;
	}
}
