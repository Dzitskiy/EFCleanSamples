using AppServices.Orders.Services;
using AppServices.Products.Services;
using AppServices.Users.Repository;
using AppServices.Users.Services;
using DataAccess;
using DataAccess.Data;
using DataAccess.Repositories;
using Domain.Entities;
using Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()

      .AddJsonOptions(options =>
                    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IProductService, ProductService>();

builder.Services.AddScoped<IUserRepository, UserRepository>();


builder.Services.AddScoped<IRepository<User>, EfCoreRepository<User>>();
builder.Services.AddScoped<IRepository<Order>, EfCoreRepository<Order>>();
builder.Services.AddScoped<IRepository<Product>, EfCoreRepository<Product>>();

builder.Services.AddScoped(typeof(IRepository<>), typeof(EfCoreRepository<>));

//builder.Services.AddSingleton(typeof(IRepository<User>), (sp) =>
//new InMemoryRepository<User>(FakeDataFactory.Users));
//builder.Services.AddSingleton(typeof(IRepository<Product>), (sp) =>
//new InMemoryRepository<Product>( new List<Product>()));

//1
builder.Services.AddDbContext<ApplicationDbContext>(

    //5
    options =>
 options.UseSqlite(builder.Configuration.GetConnectionString("SqliteConnection"))
//6
//options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))


           );



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
