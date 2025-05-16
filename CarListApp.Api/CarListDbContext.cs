using Microsoft.EntityFrameworkCore;

public class CarListDbContext : DbContext
{
	public CarListDbContext(DbContextOptions<CarListDbContext> options) : base(options)
	{
	}

	public DbSet<Car> Cars { get; set; }
	
	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		base.OnModelCreating(modelBuilder);

		modelBuilder.Entity<Car>()
			.HasData(
				new Car { Id = 1, Make = "Toyota", Model = "Camry", Vin = 123456 },
				new Car { Id = 2, Make = "Honda", Model = "Civic", Vin = 654321 },
				new Car { Id = 3, Make = "Ford", Model = "Mustang", Vin = 789012 },
				new Car { Id = 4, Make = "Chevrolet", Model = "Malibu", Vin = 345678 },
				new Car { Id = 5, Make = "Nissan", Model = "Altima", Vin = 901234 },
				new Car { Id = 6, Make = "Hyundai", Model = "Elantra", Vin = 567890 },
				new Car { Id = 7, Make = "Kia", Model = "Optima", Vin = 234567 },
				new Car { Id = 8, Make = "Volkswagen", Model = "Jetta", Vin = 890123 },
				new Car { Id = 9, Make = "Subaru", Model = "Impreza", Vin = 456789 },
				new Car { Id = 10, Make = "Mazda", Model = "3", Vin = 123789 }
			);
	}
}
