using Ecommerce.Application.Interfaces;
using Ecommerce.Application.Services;
using Ecommerce.Core.Repositories;
using Ecommerce.Core.Repositories.Base;
using Ecommerce.Infraestructure.Data;
using Ecommerce.Infraestructure.Repository;
using Ecommerce.Infraestructure.Repository.Base;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped<IProductRepository, ProductRepository>();

builder.Services.AddDbContext<EcommerceContext>(c =>
c.UseInMemoryDatabase("EcommerceNetConnection"));

builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

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
