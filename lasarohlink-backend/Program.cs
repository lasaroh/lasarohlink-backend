using lasarohlink_backend.Data;
using lasarohlink_backend.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<LasarohLinkDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("LasarohLinkDatabase")));

// Registers the services for dependency injection, ensuring a new instance is created for each HTTP request.
builder.Services.AddScoped<UrlService>();
builder.Services.AddScoped<LogService>();

// Add CORS service
builder.Services.AddCors(options =>
{
	options.AddPolicy("MyPolicy", policy =>
	{
		policy.WithOrigins("http://localhost:4321")
			  .AllowAnyHeader()
			  .AllowAnyMethod();
	});
});

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors("MyPolicy");

app.MapControllers();

// Redirect requests from the short URL to the actual API path
app.MapGet("/{ShortenedUrl}", (string ShortenedUrl) =>
{
	return Results.Redirect($"/api/Url/{ShortenedUrl}");
});

app.Run();