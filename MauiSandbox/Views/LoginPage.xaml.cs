using MauiSandbox.ViewModels;

namespace MauiSandbox.Views;

public partial class LoginPage : ContentPage
{
	public LoginPage (LoginViewModel loginViewModel)
	{
		InitializeComponent ();
		BindingContext = loginViewModel;
	}
}
