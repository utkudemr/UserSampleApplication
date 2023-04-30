using FluentValidation;
using Serilog;
using UserSample.Business.Service;
using UserSample.Data.Service;
using UserSample.Domain.Service.Mapper;
using UserSample.Domain.Service.Models.User;
using UserSample.Domain.Service.Validation.FluentValidation;

var builder = WebApplication.CreateBuilder(args);

var logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .Enrich.FromLogContext()
    .CreateLogger();
builder.Logging.ClearProviders();
builder.Logging.AddSerilog(logger);

builder.Services.AddControllers();
builder.Services.AddUserSampleDataServices(builder.Configuration);
builder.Services.AddUserSampleBusinessServices(builder.Configuration);
builder.Services.AddUserSampleIntegrationServices(builder.Configuration);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(MapperProfile));

builder.Services.AddScoped<IValidator<CreateUserRequestDto>, CreateCustomerRequestValidator>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

app.Run();
