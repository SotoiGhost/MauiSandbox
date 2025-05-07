using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MauiSandbox.Models;

public class Option<T> : INotifyPropertyChanged, IEquatable<Option<T>> {

	public event PropertyChangedEventHandler? PropertyChanged;
	protected virtual void OnPropertyChanged ([CallerMemberName] string? propertyName = null)
	{
		PropertyChanged?.Invoke (this, new PropertyChangedEventArgs (propertyName));
	}

	#region Properties
	/***************************************************************************************
	   Properties
   ***************************************************************************************/
	public T Type { get; set; }
	public byte Id { get; set; }
	#endregion

	#region Lifecycle
	/***************************************************************************************
	   Lifecycle
   ***************************************************************************************/

	public Option ()
	{

	}

	public Option (T type)
	{
		this.Type = type;
	}

	#endregion

	#region BindingProperties
	/***************************************************************************************
	   Binding Properties
   ***************************************************************************************/

	private string _name;
	public string Name {
		get => _name;
		set { _name = value; OnPropertyChanged (); }
	}

	public bool CanBeEdited { get; set; }
	public bool CanBeDeleted { get; set; }

	private bool _isSelected;
	public bool IsSelected {
		get => _isSelected;
		set { _isSelected = value; OnPropertyChanged (); }
	}

	private bool _isInEditMode;
	public bool IsInEditMode {
		get => _isInEditMode;
		set { _isInEditMode = value; OnPropertyChanged (); }
	}

	private bool _isTitle;
	public bool IsTitle {
		get => _isTitle;
		set { _isTitle = value; OnPropertyChanged (); }
	}

	private bool _isSubtitle;
	public bool IsSubtitle {
		get => _isSubtitle;
		set { _isSubtitle = value; OnPropertyChanged (); }
	}

	private bool _isEmptyItem;
	public bool IsEmptyItem {
		get => _isEmptyItem;
		set { _isEmptyItem = value; OnPropertyChanged (); }
	}

	private bool _isLastItem;
	public bool IsLastItem {
		get => _isLastItem;
		set { _isLastItem = value; OnPropertyChanged (); }
	}

	private bool _isUnsavedItem;
	public bool IsUnsavedItem {
		get => _isUnsavedItem;
		set { _isUnsavedItem = value; OnPropertyChanged (); }
	}

	private bool _isUnsavedTextOverwrited;
	public bool IsUnsavedTextOverwrited {
		get => _isUnsavedTextOverwrited;
		set { _isUnsavedTextOverwrited = value; OnPropertyChanged (); }
	}

	private bool _hideItem;
	public bool HideItem {
		get => _hideItem;
		set { _hideItem = value; OnPropertyChanged (); }
	}

	#endregion

	#region Overrides
	/***************************************************************************************
	   Overrides
   ***************************************************************************************/
	public override bool Equals (object obj)
	{
		if (obj is null) {
			return false;
		}

		if (!(obj is Option<T> option)) return false;

		if (string.IsNullOrEmpty (Name) == false) {
			return (this.Id == option.Id &&
					this.Name == option.Name);
		} else {
			return this.Id == option.Id;
		}
	}

	public bool Equals (Option<T> other)
	{
		if (other is null) {
			return false;
		}

		if (!(other is Option<T> option)) return false;

		if (string.IsNullOrEmpty (Name) == false) {
			return (this.Id == option.Id &&
					this.Name == option.Name);
		} else {
			return this.Id == option.Id;
		}
	}

	public override int GetHashCode ()
	{
		return (this.Id).GetHashCode ();
	}

	public static bool operator == (Option<T> lhs, Option<T> rhs)
	{
		if (lhs is null) {
			if (rhs is null) {
				return true;
			}

			return false;
		}

		return lhs.Equals (rhs);
	}

	public static bool operator != (Option<T> lhs, Option<T> rhs)
	{
		return !(lhs == rhs);
	}
	#endregion
}
