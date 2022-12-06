﻿using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.Identity.Web;

namespace SuggestionAppUI
{
    public static class RegisterServices
    {
        /// <summary>
        /// Dependency Injection.
        /// </summary>
        /// <param name="builder"></param>
        public static void ConfigureServices(this WebApplicationBuilder builder)
        {
            // Add services to the container.
            builder.Services.AddRazorPages();
            builder.Services.AddServerSideBlazor();
            builder.Services.AddMemoryCache();

            builder.Services.AddAuthentication(OpenIdConnectDefaults.AuthenticationScheme)
                .AddMicrosoftIdentityWebApp(builder.Configuration.GetSection("AzureAdB2C"));

            builder.Services.AddAuthorization(options => {
                options.AddPolicy("Admin", policy =>
                {
                    policy.RequireClaim("JobTitle", "Admin");
                });
            });

            builder.Services.AddSingleton<IDbConnection, DbConnection>();
            builder.Services.AddSingleton<ICategoryData, MongoCategoryData>();
            builder.Services.AddSingleton<IStatusData, MongoStatusData>();
            builder.Services.AddSingleton<ISuggestioniData, MongoSuggestioniData>();
            builder.Services.AddSingleton<IUserData, MongoUserData>();
        }
    }
}
