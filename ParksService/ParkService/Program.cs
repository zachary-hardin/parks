using Microsoft.EntityFrameworkCore;
using ParksService.Data;
using ParksService.Endpoints;
using ParksService.Repository;

var builder = WebApplication.CreateBuilder(args);

// Pull the connection string
var cs = builder.Configuration.GetConnectionString("ParksDb");

builder.Services.AddDbContext<ParksDbContext>(opts => opts.UseNpgsql(cs));
builder.Services.AddScoped<IParkRepository, ParkRepository>();

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.UseParkEndpoints();
app.Run();