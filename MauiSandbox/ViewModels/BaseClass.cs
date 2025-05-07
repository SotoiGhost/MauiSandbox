using System.Collections.ObjectModel;

using MauiSandbox.Interfaces;
using MauiSandbox.Models;

namespace MauiSandbox.ViewModels;

public class PresetSettingsListener<T> : IDeletablePresetSettingsListener<T> {
	public PresetSettingsListener ()
	{
	}

	public virtual T PresetMode {
		get;
		set;
	}

	public virtual Option<T> OptionMode {
		get;
		set;
	}

	public virtual ObservableCollection<Option<T>> PresetModeList {
		get;
		set;
	}

	public virtual void OnPresetModeChanged (T mode)
	{
	}

	public virtual void OnPresetModeChanged (Option<T> mode)
	{
	}

	public virtual void OnPresetModeDeleted (Option<T> mode)
	{
	}

	public virtual void OnPresetModeEdited (Option<T> mode)
	{
	}

	public virtual void SetPresetModeList ()
	{
	}
}

public class StringPresetSettingsListener : PresetSettingsListener<string> {
	public StringPresetSettingsListener ()
	{
	}

	public override void SetPresetModeList ()
	{
		PresetModeList = new ObservableCollection<Option<string>> {
			new Option<string> ("Test") { Name = "Option 1", IsSelected = false },
			new Option<string> ("Test") { Name = "Option 2", IsSelected = false },
			new Option<string> ("Test") { Name = "Option 3", IsSelected = false },
			new Option<string> ("Test") { Name = "Option 4", IsSelected = false },
			new Option<string> ("Test") { Name = "Option 5", IsSelected = false }
		};
	}
}

public class IntPresetSettingsListener : PresetSettingsListener<int> {
	public IntPresetSettingsListener ()
	{
	}

	public override void SetPresetModeList ()
	{
		PresetModeList = new ObservableCollection<Option<int>> {
			new Option<int> (1) { Name = "Option 1", IsSelected = false },
			new Option<int> (2) { Name = "Option 2", IsSelected = false },
			new Option<int> (3) { Name = "Option 3", IsSelected = false },
			new Option<int> (4) { Name = "Option 4", IsSelected = false },
			new Option<int> (5) { Name = "Option 5", IsSelected = false }
		};
	}
}
