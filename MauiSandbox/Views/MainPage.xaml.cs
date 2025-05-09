using MauiSandbox.Models;
using MauiSandbox.ViewModels;

namespace MauiSandbox.Views;

public partial class MainPage : ContentPage
{
	public MainPage (CarListViewModel carListViewModel)
	{
		InitializeComponent ();
		BindingContext = carListViewModel;
	}
}

