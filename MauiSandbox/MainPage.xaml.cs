using System.Collections.ObjectModel;

using MauiSandbox.Controls;
using MauiSandbox.ViewModels;

namespace MauiSandbox;

public partial class MainPage : ContentPage {
	int count = 0;
	MainViewModel _viewModel = new MainViewModel ();

	public MainPage ()
	{
		InitializeComponent ();
		BindingContext = _viewModel;
	}

	private void OnCounterClicked (object sender, EventArgs e)
	{
		count++;

		if (count == 1)
			CounterBtn.Text = $"Clicked {count} time";
		else
			CounterBtn.Text = $"Clicked {count} times";

		SemanticScreenReader.Announce (CounterBtn.Text);
	}

	private void AddOptionClicked (object sender, EventArgs e)
	{
		// _itemSource.Add (new AINRModel { Name = $"Option {_itemSource.Count + 1}", IsSelected = false });
	}
}

