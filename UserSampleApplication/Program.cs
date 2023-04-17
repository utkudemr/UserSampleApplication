using FluentValidation;
using UserSample.Business.Service.Abstracts;
using UserSample.Business.Service.Concretes;
using UserSample.Domain.Service.Mapper;
using UserSample.Domain.Service.Models.User;
using UserSample.Domain.Service.Validation.FluentValidation;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(MapperProfile));
builder.Services.AddScoped<ICreateCustomerService, CreateCustomerService>();
builder.Services.AddScoped<IGetCustomerService, GetCustomerService>();
builder.Services.AddScoped<IValidator<CreateUserRequestDto>, CreateCustomerRequestValidator>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
