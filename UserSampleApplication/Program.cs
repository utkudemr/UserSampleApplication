using FluentValidation;
using Serilog;
using UserSample.Business.Service.Abstracts;
using UserSample.Business.Service.Concretes;
using UserSample.Business.Service.Services.Abstracts;
using UserSample.Domain.Service.Mapper;
using UserSample.Domain.Service.Models.User;
using UserSample.Domain.Service.Validation.FluentValidation;
using UserSample.Integration.Service.Services;

var builder = WebApplication.CreateBuilder(args);

var logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .Enrich.FromLogContext()
    .CreateLogger();
builder.Logging.ClearProviders();
builder.Logging.AddSerilog(logger);
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(MapperProfile));
builder.Services.AddScoped<ICreateCustomerService, CreateCustomerService>();
builder.Services.AddScoped<IUserIntegrationService, UserIntegrationService>();
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
