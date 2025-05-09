using MauiSandbox.ViewModels;

namespace MauiSandbox.Views;

public partial class CarDetailsPage : ContentPage
{
	public CarDetailsPage(CarDetailsViewModel carDetailsViewModel)
	{
		InitializeComponent();
		BindingContext = carDetailsViewModel;
	}
}
