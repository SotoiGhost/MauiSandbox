using System;
using System.Collections.ObjectModel;

using MauiSandbox.Models;

namespace MauiSandbox.Interfaces;

public interface IPresetSettingsListener<T> {
	T PresetMode { get; set; }
	Option<T> OptionMode { get; set; }
	ObservableCollection<Option<T>> PresetModeList { get; set; }

	void OnPresetModeChanged (T mode);
	void OnPresetModeChanged (Option<T> mode);
	void OnPresetModeEdited (Option<T> mode);
	void SetPresetModeList ();
}
