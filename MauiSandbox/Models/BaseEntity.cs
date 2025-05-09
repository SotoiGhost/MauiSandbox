using SQLite;

namespace MauiSandbox.Models;

public abstract class BaseEntity {
	[PrimaryKey, AutoIncrement]
	public int Id { get; set; }
}
