using System;

using CommunityToolkit.Mvvm.ComponentModel;

using MauiSandbox.Models;

namespace MauiSandbox.ViewModels;

[QueryProperty (nameof (Car), nameof (Car))]
public partial class CarDetailsViewModel : BaseViewModel {
	[ObservableProperty]
	Car? car;

	public CarDetailsViewModel ()
	{
	}

	partial void OnCarChanged (Car? value)
	{
		if (value == null)
			Title = "Car Details";
		else
			Title = $"Car Details - {value!.Make} {value!.Model}";
	}
}
