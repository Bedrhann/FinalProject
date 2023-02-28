using FinalProject.Application;
using FinalProject.Application.Validators.CategoryValidators;
using FinalProject.Infrastructure;
using FinalProject.Persistence;
using FluentValidation.AspNetCore;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers()
    .AddFluentValidation(configuration => configuration.RegisterValidatorsFromAssemblyContaining<CreateCategoryValidator>());

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddResponseCaching();

builder.Services.AddSwaggerGen(options =>//Swagger aray�z�nde Authentication kullanabilmek i�in aray�z ekliyoruz.
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

builder.Services.AddPersistenceServices(builder.Configuration, builder.Environment.EnvironmentName);
builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices(builder.Configuration);
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

app.MapControllers();
app.Run();
