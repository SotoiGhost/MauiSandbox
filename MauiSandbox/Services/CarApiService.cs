using System;
using System.Net.Http.Json;
using System.Text.Json.Serialization;

using MauiSandbox.Models;

using Newtonsoft.Json;

namespace MauiSandbox.Services;

public class CarApiService {
	readonly HttpClient httpClient;
	public const string BaseAddress = "https://9997-2806-264-5488-9529-25d3-b19c-9371-c3c9.ngrok-free.app";
	public string StatusMessage { get; set; } = string.Empty;

	public CarApiService ()
	{
		httpClient = new HttpClient {
			BaseAddress = new Uri (BaseAddress)
		};
	}

	public async Task<List<Car>?> GetCars ()
	{
		try {
			var response = await httpClient.GetStringAsync ("/cars");
			var cars = JsonConvert.DeserializeObject<List<Car>> (response);
			return cars;
		} catch (HttpRequestException e) {
			StatusMessage = $"Error: {e.Message}";
			return null;
		}
	}

	public async Task<Car?> GetCar (int id)
	{
		try {
			var response = await httpClient.GetStringAsync ($"/cars/{id}");
			var car = JsonConvert.DeserializeObject<Car> (response);
			return car;
		} catch (HttpRequestException e) {
			StatusMessage = $"Error: {e.Message}";
			return null;
		}
	}

	public async Task AddCar (Car car)
	{
		try {
			var response = await httpClient.PostAsJsonAsync ($"/cars", car);
			response.EnsureSuccessStatusCode ();
			StatusMessage = "Car added successfully.";
		} catch (HttpRequestException e) {
			StatusMessage = $"Error: {e.Message}";
		}
	}

	public async Task DeleteCar (int id)
	{
		try {
			var response = await httpClient.DeleteAsync ($"/cars/{id}");
			response.EnsureSuccessStatusCode ();
			StatusMessage = "Car deleted successfully.";
		} catch (HttpRequestException e) {
			StatusMessage = $"Error: {e.Message}";
		}
	}

	public async Task UpdateCar (int id, Car car)
	{
		try {
			var response = await httpClient.PutAsJsonAsync ($"/cars/{id}", car);
			response.EnsureSuccessStatusCode ();
			StatusMessage = "Car updated successfully.";
		} catch (HttpRequestException e) {
			StatusMessage = $"Error: {e.Message}";
		}
	}
}
