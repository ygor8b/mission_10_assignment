// Program.cs
// Entry point for the ASP.NET Core Web API

using Microsoft.EntityFrameworkCore;
using BowlingApi.Data;

var builder = WebApplication.CreateBuilder(args);

// Register controller services for API endpoints
builder.Services.AddControllers();

// Configure SQLite database connection using the BowlingLeague database file
var dbPath = Path.Combine(AppContext.BaseDirectory, "Data", "BowlingLeague.sqlite");
builder.Services.AddDbContext<BowlingContext>(options =>
    options.UseSqlite($"Data Source={dbPath}"));

// Configure CORS to allow the Vite React dev server (port 5173) to call this API
builder.Services.AddCors(options =>
    options.AddPolicy("AllowReact", p =>
        p.WithOrigins("http://localhost:5173")
          .AllowAnyMethod()
          .AllowAnyHeader()));

var app = builder.Build();

// Enable CORS middleware and map controller routes
app.UseCors("AllowReact");
app.MapControllers();
app.Run();