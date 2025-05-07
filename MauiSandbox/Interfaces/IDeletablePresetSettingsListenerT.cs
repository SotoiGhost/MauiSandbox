using System;

using MauiSandbox.Models;

namespace MauiSandbox.Interfaces;

public interface IDeletablePresetSettingsListener<T> : IPresetSettingsListener<T> {
	void OnPresetModeDeleted (Option<T> mode);
}
