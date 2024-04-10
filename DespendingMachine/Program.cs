using DataLayer;
using DataLayer.Repositories;
using Despending.Logic.Abstractions;
using Despending.Logic.Services;
using GoodsLibrary.Abstractions;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DespendingDbContext>(
    options =>
    {
        options.UseNpgsql(builder.Configuration.GetConnectionString(nameof(DespendingDbContext)));
    }

    );


builder.Services.AddScoped<IGoodRepository, GoodRepository>();
builder.Services.AddScoped<ICoinRepository, CoinRepository>();
builder.Services.AddScoped<ISecret, SecretRepository>();
builder.Services.AddScoped<IDespendingService, DespendingService>();

builder.Services.AddScoped<ICreate, OnCreate>();

var app = builder.Build();

var scope = app.Services.CreateScope();
var onCreate = scope.ServiceProvider.GetRequiredService<ICreate>();
onCreate.InitializeAsync();

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
