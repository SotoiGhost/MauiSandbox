using System;
using System.Windows.Input;

namespace MauiSandbox;

public class PageViewModel {
	ICommand? navigateToCommand;
	public ICommand NavigateToCommand => navigateToCommand ??= new Command<Type> (NavigateTo);

	private async void NavigateTo (Type pageType)
	{
		Page page = (Page) Activator.CreateInstance (pageType)! ?? throw new InvalidOperationException ("Could not create page");
		INavigation navigation = Application.Current!.Windows [0].Page!.Navigation;
		await Task.Delay (500);	
		await navigation.PushAsync (page);
	}
}
