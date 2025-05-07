using System.Collections.ObjectModel;

using MauiSandbox.Enums;
using MauiSandbox.Interfaces;
using MauiSandbox.Models;

namespace MauiSandbox.ViewModels;

public partial class MainViewModel : BindableObject, IDeletablePresetSettingsListener<MIC_EQ_SLOT> {
	private IPresetSettingsListener<MIC_EQ_SLOT> _micEQListener => this;

	MIC_EQ_SLOT _micEQPresetMode;
	MIC_EQ_SLOT IPresetSettingsListener<MIC_EQ_SLOT>.PresetMode {
		get => _micEQPresetMode;
		set => _micEQPresetMode = value;
	}

	Option<MIC_EQ_SLOT> _micEQOptionMode;
	Option<MIC_EQ_SLOT> IPresetSettingsListener<MIC_EQ_SLOT>.OptionMode {
		get => _micEQOptionMode;
		set => _micEQOptionMode = value;
	}

	ObservableCollection<Option<MIC_EQ_SLOT>> _micEQPresetModeList;
	ObservableCollection<Option<MIC_EQ_SLOT>> IPresetSettingsListener<MIC_EQ_SLOT>.PresetModeList {
		get => _micEQPresetModeList;
		set => _micEQPresetModeList = value;
	}

	public ObservableCollection<Option<MIC_EQ_SLOT>> MicEQPresetModeList {
		get => _micEQPresetModeList;
		set => _micEQPresetModeList = value;
	}

	void IPresetSettingsListener<MIC_EQ_SLOT>.OnPresetModeChanged (MIC_EQ_SLOT mode)
	{
		_listener<MIC_EQ_SLOT> ().PresetMode = mode;
	}

	void IPresetSettingsListener<MIC_EQ_SLOT>.OnPresetModeChanged (Option<MIC_EQ_SLOT> mode)
	{
		_listener<MIC_EQ_SLOT> ().OptionMode = mode;
		_listener<MIC_EQ_SLOT> ().PresetMode = mode.Type;
	}

	void IPresetSettingsListener<MIC_EQ_SLOT>.OnPresetModeEdited (Option<MIC_EQ_SLOT> mode)
	{

	}

	void IPresetSettingsListener<MIC_EQ_SLOT>.SetPresetModeList ()
	{
		_listener<MIC_EQ_SLOT> ().PresetModeList = new ObservableCollection<Option<MIC_EQ_SLOT>> {
			CreatePresetOption (MIC_EQ_SLOT.SIGNATURE_SOUND),
			CreatePresetOption (MIC_EQ_SLOT.FULL),
			CreatePresetOption (MIC_EQ_SLOT.CLARITY),
			CreatePresetOption (MIC_EQ_SLOT.SMOOTH),
		};
	}

	void IDeletablePresetSettingsListener<MIC_EQ_SLOT>.OnPresetModeDeleted (Option<MIC_EQ_SLOT> mode)
	{

	}
}
