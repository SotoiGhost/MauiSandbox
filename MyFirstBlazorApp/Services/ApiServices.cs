using Microsoft.Extensions.Configuration;

public class ApiService {
	private readonly IConfiguration _configuration;

	// Constructor that injects IConfiguration to access configuration settings
	public ApiService (IConfiguration configuration)
	{
		_configuration = configuration;
	}

	// Method to get the API base URL from configuration
	public string GetApiBaseUrl ()
	{
		return _configuration ["ApiSettings:BaseUrl"] ?? "https://default-api-url.com";
	}
}
