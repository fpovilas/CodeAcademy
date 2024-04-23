
using JWTAuth.DB;
using JWTAuth.Service;
using JWTAuth.Service.Interface;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

namespace JWTAuth
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();

            #region JWT Token for Swagger

            //For Swagger to get Auth for JWT Token
            //builder.Services.AddSwaggerGen(options =>
            //{
            //    options.SwaggerDoc("v1", new OpenApiInfo
            //    {
            //        Version = "v1",
            //        Title = "WebAPI",
            //        Description = "Product WebAPI"
            //    });
            //    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            //    {
            //        Scheme = "Bearer",
            //        BearerFormat = "JWT",
            //        In = ParameterLocation.Header,
            //        Name = "Authorization",
            //        Description = "Bearer Authentication with JWT Token",
            //        Type = SecuritySchemeType.Http
            //    });
            //    options.AddSecurityRequirement(new OpenApiSecurityRequirement {
            //        {
            //        new OpenApiSecurityScheme {
            //            Reference = new OpenApiReference {
            //                Id = "Bearer",
            //                Type = ReferenceType.SecurityScheme
            //            }
            //        },
            //        new List <string> ()
            //        }
            //    });
            //});

            #endregion

            #region API Key for Swagger

            //For Swagger to get Auth for Api KEY
            //builder.Services.AddSwaggerGen(options =>
            //{
            //    options.SwaggerDoc("v1", new OpenApiInfo
            //    {
            //        Version = "v1",
            //        Title = "WebAPI",
            //        Description = "Product WebAPI"
            //    });
            //    options.AddSecurityDefinition("ApiKey", new OpenApiSecurityScheme
            //    {
            //        In = ParameterLocation.Header,
            //        Name = "ApiKey",
            //        Description = "Input Api Key",
            //        Type = SecuritySchemeType.ApiKey
            //    });
            //    options.AddSecurityRequirement(new OpenApiSecurityRequirement {
            //        {
            //        new OpenApiSecurityScheme {
            //            Reference = new OpenApiReference {
            //                Id = "ApiKey",
            //                Type = ReferenceType.SecurityScheme
            //            }
            //        },
            //        new List <string> ()
            //        }
            //    });
            //});

            #endregion

            //For Authentication
            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.FromSeconds(0),
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = builder.Configuration["Jwt:Issuer"],
                    ValidAudience = builder.Configuration["Jwt:Issuer"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]!))
                };
            });

            builder.Services.AddDbContext<UserContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DatabaseUser")));
            builder.Services.AddDbContext<CarContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DatabaseCar")));
            builder.Services.AddTransient<IJWTService, JWTService>();
            builder.Services.AddScoped<ICarService, CarService>();

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
        }
    }
}
