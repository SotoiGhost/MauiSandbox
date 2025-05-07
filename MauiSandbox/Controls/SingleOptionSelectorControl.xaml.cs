using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace MauiSandbox.Controls;

/// <summary>
/// TODO : For testing purpose
/// </summary>
public class AINRModel {
	public string Name { get; set; }
	public bool IsSelected { get; set; }
}

public partial class SingleOptionSelectorControl : Border {
	public SingleOptionSelectorControl ()
	{
		InitializeComponent ();
	}

	#region ItemSource
	public static readonly BindableProperty ItemSourceProperty = BindableProperty.Create (
		nameof (ItemSource),
		typeof (IEnumerable<AINRModel>),
		typeof (SingleOptionSelectorControl),
		null);

	public IEnumerable<AINRModel> ItemSource {
		get => (IEnumerable<AINRModel>) GetValue (ItemSourceProperty);
		set => SetValue (ItemSourceProperty, value);
	}
	#endregion ItemSource

	#region SelectedItem
	public static readonly BindableProperty SelectedItemProperty = BindableProperty.Create (
		nameof (SelectedItem),
		typeof (AINRModel),
		typeof (SingleOptionSelectorControl),
		null,
		defaultBindingMode: BindingMode.TwoWay,
		propertyChanged: OnSelectedItemChanged);

	public AINRModel SelectedItem {
		get => (AINRModel) GetValue (SelectedItemProperty);
		set => SetValue (SelectedItemProperty, value);
	}
	#endregion ItemSource

	#region OnPropertyChanged
	protected override void OnPropertyChanged ([CallerMemberName] string propertyName = null)
	{
		base.OnPropertyChanged (propertyName);
		if (propertyName == ItemSourceProperty.PropertyName) {
			if (ItemSource != null) {
				BindableLayout.SetItemsSource (containerList, ItemSource);
			}
		}
	}
	#endregion OnPropertyChanged

	private ICommand _presetClickedInternalCommand;
	public ICommand PresetClickedInternalCommand => _presetClickedInternalCommand ??=
		new Command<AINRModel> ((item) => {
			item.IsSelected = true;
			SelectedItem = item;
		});

	#region Internals
	private static void OnSelectedItemChanged (BindableObject bindable, object oldValue, object newValue)
	{
		var control = (SingleOptionSelectorControl) bindable;
		control.UpdateSelectedItem ();
	}

	private void UpdateSelectedItem ()
	{
		foreach (var child in this.containerList.Children) {
			if (child is Microsoft.Maui.Controls.View view) {
				var item = view.BindingContext;
				if (item != null) {
					view.BackgroundColor = item == SelectedItem ?
						Colors.LightGray :
						Colors.DarkGray;
				}
			}
		}
	}

	private void TapGestureRecognizer_Tapped (object sender, TappedEventArgs e)
	{
		string name = ((Microsoft.Maui.Controls.Label) ((StackLayout) sender).FirstOrDefault ()).Text;
		var item = ItemSource.FirstOrDefault (item => item.Name == name);
		item.IsSelected = true;
		SelectedItem = item;

		Console.WriteLine ($"Selected : {name}");
	}
	#endregion
}
