using Microsoft.EntityFrameworkCore;
using WebApiP1.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//injected DbContext class 
/* Dependency injection is a design pattern used to increase maintainabilitiy and testability of
 * applications by reducing the coupling b/w components.
 * instead of instantiating objects with in the class those objects are passed as parameters to the class
 like passing it to constructor or method. */

builder.Services.AddDbContext<ClgDetailsDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("WebApip1ConnectionString")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
