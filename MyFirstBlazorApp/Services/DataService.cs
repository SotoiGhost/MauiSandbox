namespace MyFirstBlazorApp.Services;

public class DataService {
	public async Task<List<string>> GetProductsAsync ()
	{
		await Task.Delay (1000); // Simulate a delay for data fetching
		return [
			"Product 1",
			"Product 2",
			"Product 3",
			"Product 4",
			"Product 5"
		];
	}
}
