using System.Runtime.CompilerServices;
using System.Windows.Input;

using MauiSandbox.Models;

using Microsoft.Maui.Controls.Shapes;
using Microsoft.Maui.Layouts;

using MauiControls = Microsoft.Maui.Controls;

namespace MauiSandbox.Controls.Generics;

public class SingleOptionSelectorControl<T> : Border {
	private FlexLayout _containerList;

	#region Lifecycle
	/***************************************************************************************
     Lifecycle
     ***************************************************************************************/

	public SingleOptionSelectorControl ()
	{
		this.CustomizeBorder ();
		Content = this.CreateContent ();
	}
	#endregion

	#region BindableProperties
	/***************************************************************************************
       Bindable Properties
     ***************************************************************************************/
	#region PresetTitleProperty
	public static readonly BindableProperty TitleProperty = BindableProperty.Create (
		propertyName: nameof (Title),
		returnType: typeof (string),
		declaringType: typeof (SingleOptionSelectorControl<T>),
		defaultValue: "");

	public string Title {
		get => (string) GetValue (TitleProperty);
		set => SetValue (TitleProperty, value);
	}
	#endregion

	#region ItemSource
	public static readonly BindableProperty ItemSourceProperty = BindableProperty.Create (
		nameof (ItemSource),
		typeof (IEnumerable<Option<T>>),
		typeof (SingleOptionSelectorControl<T>),
		null);

	public IEnumerable<Option<T>> ItemSource {
		get => (IEnumerable<Option<T>>) GetValue (ItemSourceProperty);
		set => SetValue (ItemSourceProperty, value);
	}
	#endregion

	#region SelectedItem
	public static readonly BindableProperty SelectedItemProperty = BindableProperty.Create (
		nameof (SelectedItem),
		typeof (Option<T>),
		typeof (SingleOptionSelectorControl<T>),
		null,
		defaultBindingMode: BindingMode.TwoWay,
		propertyChanged: OnSelectedItemChanged);

	public Option<T> SelectedItem {
		get => (Option<T>) GetValue (SelectedItemProperty);
		set => SetValue (SelectedItemProperty, value);
	}
	#endregion

	#region PresetClickedCommandProperty
	public static readonly BindableProperty PresetClickedCommandProperty = BindableProperty.Create (
		propertyName: nameof (PresetClickedCommand),
		returnType: typeof (ICommand),
		declaringType: typeof (SingleOptionSelectorControl<T>),
		defaultValue: null);

	public ICommand PresetClickedCommand {
		get => (ICommand) GetValue (PresetClickedCommandProperty);
		set => SetValue (PresetClickedCommandProperty, value);
	}
	#endregion

	#endregion

	#region OnPropertyChanged
	protected override void OnPropertyChanged ([CallerMemberName] string propertyName = null)
	{
		base.OnPropertyChanged (propertyName);
		if (propertyName == ItemSourceProperty.PropertyName) {
			if (ItemSource != null) {
				BindableLayout.SetItemsSource (_containerList, ItemSource);
			}
		}
	}
	#endregion OnPropertyChanged

	#region Internals
	private ICommand _presetClickedInternalCommand;
	ICommand PresetClickedInternalCommand => _presetClickedInternalCommand ??=
		new Command<Option<T>> ((item) => {
			item.IsSelected = true;
			SelectedItem = item;
			PresetClickedCommand?.Execute (item);
		});

	private static void OnSelectedItemChanged (BindableObject bindable, object oldValue, object newValue)
	{
		var control = (SingleOptionSelectorControl<T>) bindable;
		control.UpdateSelectedItem ();
	}

	private void UpdateSelectedItem ()
	{
		foreach (var child in this._containerList.Children) {
			if (child is Microsoft.Maui.Controls.View view) {
				var item = view.BindingContext;
				if (item != null) {
					view.BackgroundColor = item == SelectedItem ?
						(Color) Application.Current.Resources ["PrimaryRoyalPurple_Swarm"] :
						Colors.Transparent;
				}
			}
		}
	}

	private void CustomizeBorder ()
	{
		StrokeShape = new RoundRectangle { CornerRadius = 10 };
		StrokeThickness = 0;
		MinimumHeightRequest = 34;
		Padding = 0;
		BackgroundColor = (Color) Application.Current.Resources ["EbonyClay"];
	}

	private MauiControls.View CreateContent ()
	{

		_containerList = new FlexLayout {
			Direction = FlexDirection.Row,
			Wrap = FlexWrap.Wrap,
			JustifyContent = FlexJustify.SpaceEvenly,
		};

		var dataTemplate = new DataTemplate (this.CreateItemContent);
		BindableLayout.SetItemTemplate (_containerList, dataTemplate);

		return _containerList;
	}

	private MauiControls.View CreateItemContent ()
	{
		var label = new MauiControls.Label {
			VerticalOptions = LayoutOptions.CenterAndExpand,
			HorizontalOptions = LayoutOptions.Center,
			Style = (Style) Application.Current.Resources ["LabelTurtleBeachLight12"],
			TextColor = (Color) Application.Current.Resources ["SecondaryProductNameColor"]
		};
		label.SetBinding (MauiControls.Label.TextProperty, new MauiControls.Binding ("Name"));

		var tapGestureRecognizer = new TapGestureRecognizer ();
		tapGestureRecognizer.Command = PresetClickedInternalCommand;
		tapGestureRecognizer.SetBinding (TapGestureRecognizer.CommandParameterProperty, new MauiControls.Binding ("."));

		var stackLayout = new StackLayout ();
		stackLayout.GestureRecognizers.Add (tapGestureRecognizer);
		stackLayout.Children.Add (label);
		FlexLayout.SetBasis (stackLayout, new FlexBasis (0.33f, true));

		return stackLayout;
	}
	#endregion
}
