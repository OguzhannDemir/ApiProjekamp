using ApiProjeKamp.WebApi.Context;
using ApiProjeKamp.WebApi.Entities;
using ApiProjeKamp.WebApi.ValidationRules;
using FluentValidation;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<ApiContext>();
builder.Services.AddScoped<IValidator<Product>,ProductValidator>(); // FluentValidation ile ProductValidator s�n�f�n� DI konteynerine ekliyoruz. Bu sayede, Product nesneleri i�in do�rulama i�lemleri yap�labilir.
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());//Bu sat�r sayesinde, projenizde tan�ml� t�m AutoMapper profilleri otomatik olarak y�klenir ve uygulaman�n her yerinde kullan�labilir hale gelir.


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

app.MapControllers();

app.Run();
