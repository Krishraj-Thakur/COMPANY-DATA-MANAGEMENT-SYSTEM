using API.core;
using Microsoft.EntityFrameworkCore;
using API1.AutoMapper;
using Api.Services.Interface;
using Api.Services.Service;
using API.core.DbModels;
using AutoMapper;
using API.core.DTO_s;

var builder = WebApplication.CreateBuilder(args);

//Add db1 and connection string

builder.Services.AddDbContext<API.core.DbModels.Db1Context>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
//builder.Services.AddEndpointsApiExplorer();
// Register AutoMapper

builder.Services.AddAutoMapper(typeof(MappingProfile));

// Register services

builder.Services.AddScoped<IPRService, PRService>();
builder.Services.AddScoped<IMasterService, MasterService>();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.MapControllers();

app.Run();
