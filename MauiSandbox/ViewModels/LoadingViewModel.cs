using System;
using System.Threading.Tasks;

using MauiSandbox.Views;

namespace MauiSandbox.ViewModels;

public partial class LoadingViewModel : BaseViewModel {
	public LoadingViewModel ()
	{
		CheckUserLoginDetails ();
	}

	private async void CheckUserLoginDetails ()
	{
		// Retrieve token from internal storage
		var token = await SecureStorage.GetAsync ("token");

		if (string.IsNullOrEmpty (token)) {
			await GoToLoginPage ();
		}

		// Evaluate token expiration

	}
	
	async Task GoToLoginPage ()
	{
		await Shell.Current.GoToAsync ($"{nameof (LoginPage)}");
	}

	async Task GoToMainPage ()
	{
		await Shell.Current.GoToAsync ($"{nameof (MainPage)}");
	}
}
