using FinalProject.API.Extensions;
using FinalProject.Application;
using FinalProject.Application.Validators.CategoryValidators;
using FinalProject.Infrastructure;
using FinalProject.Persistence;
using FluentValidation.AspNetCore;
using Microsoft.OpenApi.Models;
using Serilog;
using Swashbuckle.AspNetCore.Filters;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddPersistenceServices(builder.Configuration, builder.Environment.EnvironmentName);
builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices(builder.Configuration);

// Add Fluent Validation
builder.Services.AddControllers()
    .AddFluentValidation(configuration => configuration.RegisterValidatorsFromAssemblyContaining<CreateCategoryValidator>());


// Add Logging
builder.Logging.AddSerilog();
builder.Host.UseSerilog((hostContext, services, configuration) =>
{
    configuration.ReadFrom.Configuration(hostContext.Configuration);
});


builder.Services.AddSwaggerGen(options =>//Swagger arayüzünde Authentication kullanabilmek için 
{
    options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
    {
        Description = "ATTEMPT (\"bearer {token}\")",
        In = ParameterLocation.Header,
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey
    });
    options.OperationFilter<SecurityRequirementsOperationFilter>();
});


var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseResponseCaching();

app.UseAuthentication();
app.UseAuthorization();

app.UseGlobalExceptionMiddleware();

app.MapControllers();
app.Run();
