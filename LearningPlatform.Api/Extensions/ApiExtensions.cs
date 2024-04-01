﻿using LearningPlatform.Api.Endpoints;
using LearningPlatform.Api.EndPoints;
using LearningPlatform.Infrastructure;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace LearningPlatform.Api.Extensions;

public static class ApiExtensions
{
    public static void AddMappedEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapCoursesEndpoints();
        app.MapLessonsEndpoints();
        app.MapUsersEndpoints();
    }

    public static void AddApiAuthentication(
        this IServiceCollection service,
        IConfiguration configuration)
    {

        var jwtOptions = configuration.GetSection(nameof(JwtOptions)).Get<JwtOptions>();

        service.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options =>
            {
                options.TokenValidationParameters = new()
                {
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(jwtOptions!.SecretKey))
                };

                options.Events = new JwtBearerEvents
                {
                    OnMessageReceived = context =>
                    {
                        context.Token = context.Request.Cookies["testy-cookies"];

                        return Task.CompletedTask;
                    }
                };

            });

        service.AddAuthorization();
    }
}