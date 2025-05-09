using MauiSandbox.Models;

using SQLite;

namespace MauiSandbox.Services;

public class CarService (string dbPath) {
	SQLiteConnection? connection;
	readonly string dbPath = dbPath;

	public string StatusMessage { get; set; } = string.Empty;

	void Init ()
	{
		if (connection != null)
			return;

		connection = new SQLiteConnection (dbPath);
		connection.CreateTable<Car> ();
	}

	public List<Car> GetCars ()
	{
		try {
			// Init ();
			// return connection!.Table<Car> ().ToList ();

			return [
				new Car { Id = 1, Make = "Toyota", Model = "Corolla", Vin = "123456789012" },
				new Car { Id = 2, Make = "Honda", Model = "Civic", Vin = "123456789013" },
				new Car { Id = 3, Make = "Ford", Model = "Focus", Vin = "123456789014" },
				new Car { Id = 4, Make = "Chevrolet", Model = "Malibu", Vin = "123456789015" },
				new Car { Id = 5, Make = "Nissan", Model = "Altima", Vin = "123456789016" },
				new Car { Id = 6, Make = "Hyundai", Model = "Elantra", Vin = "123456789017" },
				new Car { Id = 7, Make = "Kia", Model = "Forte", Vin = "123456789018" },
				new Car { Id = 8, Make = "Volkswagen", Model = "Jetta", Vin = "123456789019" },
				new Car { Id = 9, Make = "Subaru", Model = "Impreza", Vin = "123456789020" },
				new Car { Id = 10, Make = "Mazda", Model = "3", Vin = "123456789021" },
			];
		} catch (Exception ex) {
			StatusMessage = ex.Message;
			return new List<Car> ();
		}
	}
}
