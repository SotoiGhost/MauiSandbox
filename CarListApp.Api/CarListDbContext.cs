using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

public class CarListDbContext : IdentityDbContext {
	public CarListDbContext (DbContextOptions<CarListDbContext> options) : base (options)
	{
	}

	public DbSet<Car> Cars { get; set; }

	protected override void OnModelCreating (ModelBuilder modelBuilder)
	{
		base.OnModelCreating (modelBuilder);

		modelBuilder.Entity<Car> ()
			.HasData (
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

		modelBuilder.Entity<IdentityRole> ()
			.HasData (
				new IdentityRole {
					Id = "b392bf54-e59b-440d-bbbb-4c4d2a082ec5",
					Name = "Administrator",
					NormalizedName = "ADMINISTRATOR"
				},
				new IdentityRole {
					Id = "15165f08-ee1d-40ef-aad2-63c836b50767",
					Name = "User",
					NormalizedName = "USER"
				}
			);

		var hasher = new PasswordHasher<IdentityUser> ();

		modelBuilder.Entity<IdentityUser> ()
			.HasData (
				new IdentityUser {
					Id = "5c8af4fd-cb61-4c71-8fb9-030d1539e096",
					Email = "admin@localhost.com",
					NormalizedEmail = "ADMIN@LOCALHOST.COM",
					UserName = "admin@localhost.com",
					NormalizedUserName = "ADMIN@LOCALHOST.COM",
					PasswordHash = hasher.HashPassword (null, "P@ssword1"),
					EmailConfirmed = true
				},
				new IdentityUser {
					Id = "770bf83c-1fca-4af6-9762-2bc8dd94eab7",
					Email = "user@localhost.com",
					NormalizedEmail = "USER@LOCALHOST.COM",
					UserName = "user@localhost.com",
					NormalizedUserName = "USER@LOCALHOST.COM",
					PasswordHash = hasher.HashPassword (null, "P@ssword1"),
					EmailConfirmed = true
				}
			);

		modelBuilder.Entity<IdentityUserRole<string>> ()
			.HasData (
				new IdentityUserRole<string> {
					RoleId = "b392bf54-e59b-440d-bbbb-4c4d2a082ec5",
					UserId = "5c8af4fd-cb61-4c71-8fb9-030d1539e096"
				},
				new IdentityUserRole<string> {
					RoleId = "15165f08-ee1d-40ef-aad2-63c836b50767",
					UserId = "770bf83c-1fca-4af6-9762-2bc8dd94eab7"
				}
			);
	}
}
