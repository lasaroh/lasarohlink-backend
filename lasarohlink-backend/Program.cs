using lasarohlink_backend.Data;
using lasarohlink_backend.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Configuration for PostgreSQL
string LASAROHLINK_DATABASE = Environment.GetEnvironmentVariable("LASAROHLINK_DATABASE") ?? throw new Exception("LASAROHLINK_DATABASE not found");
builder.Services.AddDbContext<LasarohLinkDbContext>(options => options.UseNpgsql(LASAROHLINK_DATABASE));

// Registers the services for dependency injection, ensuring a new instance is created for each HTTP request.
builder.Services.AddScoped<UrlService>();
builder.Services.AddScoped<LogService>();

// Add CORS service
builder.Services.AddCors(options =>
{
	options.AddPolicy("MyPolicy", policy =>
	{
		string FRONTEND_URL = Environment.GetEnvironmentVariable("FRONTEND_URL") ?? throw new Exception("FRONTEND_URL not found");
		policy.WithOrigins(FRONTEND_URL)
			  .AllowAnyHeader()
			  .AllowAnyMethod();
	});
});

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors("MyPolicy");

app.MapControllers();

app.MapGet("/", () => "LasarohLink API is working.");

// Redirect requests from the short URL to the actual API path
app.MapGet("/{ShortenedUrl}", (string ShortenedUrl) =>
{
	return Results.Redirect($"/api/Url/{ShortenedUrl}");
});

app.Run();