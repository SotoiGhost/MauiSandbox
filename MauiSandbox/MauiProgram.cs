using MauiSandbox.Services;
using MauiSandbox.ViewModels;
using MauiSandbox.Views;

using Microsoft.Extensions.Logging;

namespace MauiSandbox;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

		string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "cars.db3");
		builder.Services.AddSingleton(s => ActivatorUtilities.CreateInstance<CarService>(s, dbPath));

		builder.Services.AddSingleton<CarApiService>();

		builder.Services.AddSingleton<CarListViewModel>();
		builder.Services.AddTransient<CarDetailsViewModel>();

		builder.Services.AddSingleton<MainPage>();
		builder.Services.AddTransient<CarDetailsPage>();

#if DEBUG
		builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}
