using System;
using System.Collections.ObjectModel;
using System.Diagnostics;

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

using MauiSandbox.Models;
using MauiSandbox.Services;
using MauiSandbox.Views;

namespace MauiSandbox.ViewModels;

public partial class CarListViewModel : BaseViewModel {
	public ObservableCollection<Car> Cars { get; private set; } = [];
	readonly CarApiService carApiService;

	public CarListViewModel (CarApiService carApiService)
	{
		Title = "Car List";
		this.carApiService = carApiService;
	}

	[ObservableProperty]
	bool isRefreshing;

	[RelayCommand]
	async Task GetCarsList ()
	{
		if (IsLoading)
			return;

		try {
			IsLoading = true;

			if (Cars.Any ())
				Cars.Clear ();

			// var cars = App.CarService!.GetCars ();
			var cars = await carApiService.GetCars ();

			if (cars == null) {
				await Shell.Current.DisplayAlert ("Error", carApiService.StatusMessage, "OK");
				return;
			}

			foreach (var car in cars)
				Cars.Add (car);
		} catch (Exception ex) {
			Debug.WriteLine ($"Unable to get cars: {ex.Message}");
			await Shell.Current.DisplayAlert ("Error", ex.Message, "OK");
		} finally {
			IsLoading = false;
			IsRefreshing = false;
		}
	}

	[RelayCommand]
	async Task GetCarDetails (Car car)
	{
		if (car == null)
			return;

		await Shell.Current.GoToAsync (nameof(CarDetailsPage), true, new Dictionary<string, object> {
			[nameof(Car)] = car,
		});
	}
}
