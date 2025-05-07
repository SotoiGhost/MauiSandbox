using System.Collections.ObjectModel;
using System.Windows.Input;

using MauiSandbox.Controls;
using MauiSandbox.Enums;
using MauiSandbox.Interfaces;
using MauiSandbox.Models;

namespace MauiSandbox.ViewModels;

public partial class MainViewModel : BindableObject {
	public MainViewModel ()
	{
		// Initialize the view model
		_gameEQListener.SetPresetModeList ();
		_micEQListener.SetPresetModeList ();

		ItemSource = new ObservableCollection<AINRModel> {
			new AINRModel { Name = "Option 1", IsSelected = false },
			new AINRModel { Name = "Option 2", IsSelected = false },
			new AINRModel { Name = "Option 3", IsSelected = false },
			new AINRModel { Name = "Option 4", IsSelected = false }
		};
	}

	private ObservableCollection<AINRModel> _itemSource;
	public ObservableCollection<AINRModel> ItemSource {
		get => _itemSource;
		set {
			_itemSource = value;
			OnPropertyChanged ();
		}
	}

	ICommand _addOptionCommand;
	public ICommand AddOptionCommand {
		get {
			return _addOptionCommand ??= new Command (() => {
				// var newOption = new Option<string> ("Test") { Name = $"Option {ItemSource.Count + 1}", IsSelected = false };
				// ItemSource.Add (newOption);
				var newOption = new AINRModel { Name = $"Option {ItemSource.Count + 1}", IsSelected = false };
				ItemSource.Add (newOption);

				var t = CreatePresetOption (GAME_EQ_SLOT.UNSAVED);
				_gameEQListener.PresetModeList.Add (t);

				var t2 = CreatePresetOption (MIC_EQ_SLOT.UNSAVED);
				_micEQListener.PresetModeList.Add (t2);
			});
		}
	}

	private IPresetSettingsListener<T> _listener<T> ()
	{
		return (IPresetSettingsListener<T>) this;
	}

	private void UseCase ()
	{

	}

	private Option<T> CreatePresetOption<T> (T preset) where T : Enum
	{
		return new Option<T> {
			Type = preset,
			CanBeDeleted = false,
			CanBeEdited = false,

			Name = preset?.ToString () ?? "default",
			Id = Convert.ToByte (preset)
		};
	}

	private void ChatGPT ()
	{

	}
	
	private ICommand _presetClickedCommand;
	public ICommand PresetClickedCommand => _presetClickedCommand ??=
		new Command<object> ((item) => {
			if (item is Option<GAME_EQ_SLOT> gameEQItem) {
				// Handle string item
				Console.WriteLine ($"GAME_EQ_SLOT Item Clicked: {gameEQItem.Name}");
			} else if (item is Option<MIC_EQ_SLOT> micEQItem) {
				// Handle int item
				Console.WriteLine ($"MIC_EQ_SLOT Item Clicked: {micEQItem.Name}");
			}
		});
}
