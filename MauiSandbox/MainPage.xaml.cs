using MauiSandbox.Services;

namespace MauiSandbox;

public partial class MainPage : ContentPage
{
	int count = 0;

	public MainPage()
	{
		InitializeComponent();
	}

	private void OnCounterClicked(object sender, EventArgs e)
	{
		count++;

		if (count == 1)
			CounterBtn.Text = $"Clicked {count} time";
		else
			CounterBtn.Text = $"Clicked {count} times";

		SemanticScreenReader.Announce(CounterBtn.Text);
	}

	private void LogConsoleMessageClicked(object sender, EventArgs e)
	{
		Logger.LogMessageUsingConsole ("Hello there!");
	}

	private void LogDiagnosticsDebugMessageClicked(object sender, EventArgs e)
	{
		Logger.LogMessageUsingDiagnosticsDebug ("Hello there!");
	}

	private void LogNativeMessageClicked(object sender, EventArgs e)
	{
		Logger.LogMessageUsingNativeLogger ("Hello there!");
	}
}

