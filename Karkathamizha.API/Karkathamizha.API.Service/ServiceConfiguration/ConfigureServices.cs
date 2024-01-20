using Karkathamizha.API.IRepository;
using Karkathamizha.API.IService;
using Karkathamizha.API.IService.Common;
using Karkathamizha.API.Model.AppSettings;
using Karkathamizha.API.Service.Common;
using Karkathamizha.API.Service.Service;
using KarkaThamizha.API.Repository.Repository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

namespace Karkathamizha.API.Service.ServiceConfiguration
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddServices(this IServiceCollection service, ConfigurationManager configuration)
        {
            service.AddDataProtection();

            service.Configure<JwtSettings>(configuration.GetSection(JwtSettings.SectionName));
            service.Configure<DataProtectionTokenProviderOptions>(opt => opt.TokenLifespan = TimeSpan.FromDays(1));

            // Register interface and class which we injected
            // configure DI for application services

            service.AddScoped<ITokenGeneration, TokenGeneration>();
            service.AddScoped<IEmailService, EmailService>();
            service.AddScoped<Karkathamizha.API.IService.IAuthenticationService, Karkathamizha.API.Service.Service.AuthenticationService>();            
            service.AddScoped<IAuthenticationRepository, KarkaThamizha.API.Repository.Repository.AuthenticationRepository>();
            service.AddScoped<ICommonService, CommonService>();
            service.AddScoped<ICommonRepository, CommonRepository>();
            service.AddScoped<IUserService, UserService>();
            service.AddScoped<IUserRepository, UserRepository>();
            service.AddScoped<IBookService, BookService>();
            service.AddScoped<IBookRepository, BookRepository>();
            service.AddScoped<IPublisherService, PublisherService>();
            service.AddScoped<IPublisherRepository, PublisherRepository>();

            service.AddScoped<IBookDetailRepository, BookDetailRepository>();
            //service.AddScoped<IUserDetailRepository, UserDetailRepository>();
            service.AddScoped<IUserRolesRepository, UserRolesRepository>();
            //service.AddScoped<IUserRoleService, UserRoleService>();
            //service.AddSingleton<IMemoryCache>();
            return service;
        }

        public static IServiceCollection AddAuthentication(this IServiceCollection service, ConfigurationManager configuration)
        {
            var jwtSettings = configuration.GetSection(nameof(JwtSettings)).Get<JwtSettings>();

            service.AddSwaggerGen(opt =>
            {
                opt.SwaggerDoc("v1", new OpenApiInfo { Title = "KarkaThamizha API", Version = "v1" });
                opt.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Please enter valid token",
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    BearerFormat = "JWT",
                    Scheme = "Bearer"
                });

                opt.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type=ReferenceType.SecurityScheme,
                                Id="Bearer"
                            }
                        },
                        new string[]{}
                    }
                });
            });

            //Authentication
            service.AddAuthentication(opt =>
            {
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;

            }).AddJwtBearer(opt =>
            {
                opt.SaveToken = true;
                opt.RequireHttpsMetadata = false;
                opt.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
                {
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidAudience = jwtSettings?.validAudience,
                    ValidIssuer = jwtSettings?.validIssuer,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings?.secretKey))
                };
            });
            return service;
        }
    }
}
