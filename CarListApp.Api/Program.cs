using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddCors(options =>
{
	options.AddPolicy("AllowAllOrigins", builder =>
	{
		builder.AllowAnyOrigin()
			   .AllowAnyMethod()
			   .AllowAnyHeader();
	});
});

var dbPath = Path.Combine(Directory.GetCurrentDirectory(), "CarListApp.db");
var connection = new SqliteConnection($"Data Source={dbPath}");
builder.Services.AddDbContext<CarListDbContext>(options =>
{
	options.UseSqlite(connection);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.MapOpenApi();
}

app.UseHttpsRedirection();
app.UseCors("AllowAllOrigins");

var summaries = new[]
{
	"Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/cars", async (CarListDbContext db) => await db.Cars.ToListAsync());
app.MapGet("/cars/{id}", async (int id, CarListDbContext db) => await db.Cars.FindAsync(id) is Car car ? Results.Ok(car) : Results.NotFound());

app.MapPut ("/cars/{id}", async (int id, Car car, CarListDbContext db) => {
	var record = await db.Cars.FindAsync (id);
	if (record is null) return Results.NotFound ();

	record.Make = car.Make;
	record.Model = car.Model;
	record.Vin = car.Vin;

	await db.SaveChangesAsync ();
	return Results.NoContent ();
});

app.MapDelete ("/cars/{id}", async (int id, CarListDbContext db) => {
	var record = await db.Cars.FindAsync (id);
	if (record is null) return Results.NotFound ();

	db.Remove (record);
	await db.SaveChangesAsync ();
	return Results.NoContent ();
});

app.MapPost("/cars", async (Car car, CarListDbContext db) => {
	await db.AddAsync (car);
	await db.SaveChangesAsync ();
	return Results.Created ($"/cars/{car.Id}", car);
});

app.Run();
