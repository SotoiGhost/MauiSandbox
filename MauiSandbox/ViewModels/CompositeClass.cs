using System.Collections.ObjectModel;

using MauiSandbox.Interfaces;
using MauiSandbox.Models;

namespace MauiSandbox.ViewModels;

public class AllPresets : IDeletablePresetSettingsListener<string>, IDeletablePresetSettingsListener<int> {
	public IPresetSettingsListener<T> Listener<T> ()
	{
		return (IPresetSettingsListener<T>) this;
	}

	string IPresetSettingsListener<string>.PresetMode { get => throw new NotImplementedException (); set => throw new NotImplementedException (); }
	int IPresetSettingsListener<int>.PresetMode { get => throw new NotImplementedException (); set => throw new NotImplementedException (); }
	Option<string> IPresetSettingsListener<string>.OptionMode { get => throw new NotImplementedException (); set => throw new NotImplementedException (); }
	Option<int> IPresetSettingsListener<int>.OptionMode { get => throw new NotImplementedException (); set => throw new NotImplementedException (); }
	ObservableCollection<Option<string>> IPresetSettingsListener<string>.PresetModeList { get => throw new NotImplementedException (); set => throw new NotImplementedException (); }
	ObservableCollection<Option<int>> IPresetSettingsListener<int>.PresetModeList { get => throw new NotImplementedException (); set => throw new NotImplementedException (); }

	void IPresetSettingsListener<string>.OnPresetModeChanged (string mode)
	{
		throw new NotImplementedException ();
	}

	void IPresetSettingsListener<string>.OnPresetModeChanged (Option<string> mode)
	{
		throw new NotImplementedException ();
	}

	void IPresetSettingsListener<int>.OnPresetModeChanged (int mode)
	{
		throw new NotImplementedException ();
	}

	void IPresetSettingsListener<int>.OnPresetModeChanged (Option<int> mode)
	{
		throw new NotImplementedException ();
	}

	void IDeletablePresetSettingsListener<string>.OnPresetModeDeleted (Option<string> mode)
	{
		throw new NotImplementedException ();
	}

	void IDeletablePresetSettingsListener<int>.OnPresetModeDeleted (Option<int> mode)
	{
		throw new NotImplementedException ();
	}

	void IPresetSettingsListener<string>.OnPresetModeEdited (Option<string> mode)
	{
		throw new NotImplementedException ();
	}

	void IPresetSettingsListener<int>.OnPresetModeEdited (Option<int> mode)
	{
		throw new NotImplementedException ();
	}

	void IPresetSettingsListener<string>.SetPresetModeList ()
	{
		throw new NotImplementedException ();
	}

	void IPresetSettingsListener<int>.SetPresetModeList ()
	{
		throw new NotImplementedException ();
	}
}
