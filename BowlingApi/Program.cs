using Microsoft.EntityFrameworkCore;
using BowlingApi.Data;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();

var dbPath = Path.Combine(AppContext.BaseDirectory, "Data", "BowlingLeague.sqlite");
builder.Services.AddDbContext<BowlingContext>(options =>
    options.UseSqlite($"Data Source={dbPath}"));

builder.Services.AddCors(options =>
    options.AddPolicy("AllowReact", p =>
        p.WithOrigins("http://localhost:3000")
          .AllowAnyMethod()
          .AllowAnyHeader()));

var app = builder.Build();
app.UseCors("AllowReact");
app.MapControllers();
app.Run();