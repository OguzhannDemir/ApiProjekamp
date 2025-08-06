using ApiProjeKamp.WebApi.Context;
using ApiProjeKamp.WebApi.Entities;
using ApiProjeKamp.WebApi.ValidationRules;
using FluentValidation;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<ApiContext>();
builder.Services.AddScoped<IValidator<Product>,ProductValidator>(); // FluentValidation ile ProductValidator sýnýfýný DI konteynerine ekliyoruz. Bu sayede, Product nesneleri için doðrulama iþlemleri yapýlabilir.
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());//Bu satýr sayesinde, projenizde tanýmlý tüm AutoMapper profilleri otomatik olarak yüklenir ve uygulamanýn her yerinde kullanýlabilir hale gelir.


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
