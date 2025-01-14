﻿using FinalProject.Application.Interfaces.ExternalServices.JWT;
using FinalProject.Application.Interfaces.ExternalServices.RabbitMq;
using FinalProject.Infrastructure.Services.RabbitMqService;
using FinalProject.Infrastructure.Services.TokenService;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace FinalProject.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static void AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IGenerateToken, GenerateToken>();
            services.AddTransient<IRabbitMqPublisher, RabbitMqPublisher>();
            services.AddTransient<IRabbitMqConnection, RabbitMqConnection>();
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }
            ).AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new()
                    {
                        ValidateAudience = false,
                        ValidateIssuer = false,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Token:SecurityKey"]))
                    };
                });


        }

    }
}
