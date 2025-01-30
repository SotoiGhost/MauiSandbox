using Microsoft.Extensions.Logging;

namespace PushNotifications;

public static partial class MauiProgram
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
			})
			.RegisterFirebaseServices();

#if DEBUG
		builder.Logging.AddDebug();
#endif

		return builder.Build();
	}

	private static partial MauiAppBuilder RegisterFirebaseServices(this MauiAppBuilder builder);
}
