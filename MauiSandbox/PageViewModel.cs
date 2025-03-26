using System;
using System.Windows.Input;

namespace MauiSandbox;

public class PageViewModel : BindableObject {
	ICommand? navigateToCommand;
        public ICommand NavigateToCommand => navigateToCommand ??=
            new Command<Type>(this.NavigateTo);

	async void NavigateTo (Type type)
	{
		if (type == null)
			return;

		Page page = (Page?)Activator.CreateInstance(type) ?? throw new InvalidOperationException("Could not create page");
		await Application.Current!.Windows[0].Page!.Navigation.PushAsync(page);
	}
}
