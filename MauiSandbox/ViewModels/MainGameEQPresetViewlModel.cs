using System.Collections.ObjectModel;

using MauiSandbox.Enums;
using MauiSandbox.Interfaces;
using MauiSandbox.Models;

namespace MauiSandbox.ViewModels;

public partial class MainViewModel : BindableObject, IDeletablePresetSettingsListener<GAME_EQ_SLOT> {
	private IPresetSettingsListener<GAME_EQ_SLOT> _gameEQListener => this;

	GAME_EQ_SLOT _gameEQPresetMode;
	GAME_EQ_SLOT IPresetSettingsListener<GAME_EQ_SLOT>.PresetMode {
		get => _gameEQPresetMode;
		set => _gameEQPresetMode = value;
	}

	Option<GAME_EQ_SLOT> _gameEQOptionMode;
	Option<GAME_EQ_SLOT> IPresetSettingsListener<GAME_EQ_SLOT>.OptionMode {
		get => _gameEQOptionMode;
		set => _gameEQOptionMode = value;
	}

	ObservableCollection<Option<GAME_EQ_SLOT>> _gameEQPresetModeList;
	ObservableCollection<Option<GAME_EQ_SLOT>> IPresetSettingsListener<GAME_EQ_SLOT>.PresetModeList {
		get => _gameEQPresetModeList;
		set => _gameEQPresetModeList = value;
	}

	public ObservableCollection<Option<GAME_EQ_SLOT>> GameEQPresetModeList {
		get => _gameEQPresetModeList;
		set => _gameEQPresetModeList = value;
	}

	void IPresetSettingsListener<GAME_EQ_SLOT>.OnPresetModeChanged (GAME_EQ_SLOT mode)
	{
		_listener<GAME_EQ_SLOT> ().PresetMode = mode;
	}

	void IPresetSettingsListener<GAME_EQ_SLOT>.OnPresetModeChanged (Option<GAME_EQ_SLOT> mode)
	{
		_listener<GAME_EQ_SLOT> ().OptionMode = mode;
		_listener<GAME_EQ_SLOT> ().PresetMode = mode.Type;
	}

	void IPresetSettingsListener<GAME_EQ_SLOT>.OnPresetModeEdited (Option<GAME_EQ_SLOT> mode)
	{

	}

	void IPresetSettingsListener<GAME_EQ_SLOT>.SetPresetModeList ()
	{
		_listener<GAME_EQ_SLOT> ().PresetModeList = new ObservableCollection<Option<GAME_EQ_SLOT>> {
			CreatePresetOption (GAME_EQ_SLOT.SIGNATURE_SOUND),
			CreatePresetOption (GAME_EQ_SLOT.BASS_BOOST),
			CreatePresetOption (GAME_EQ_SLOT.BASS_AND_TREBLE_BOOST),
			CreatePresetOption (GAME_EQ_SLOT.VOCAL_BOOST),
		};
	}

	void IDeletablePresetSettingsListener<GAME_EQ_SLOT>.OnPresetModeDeleted (Option<GAME_EQ_SLOT> mode)
	{

	}
}


