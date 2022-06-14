using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelListing.Services.Configuration
{
    public static class ServiceExtensions
    {

        public static void ConfigureJwt(this IServiceCollection services, IConfiguration config)
        {
            var jwtSettings = config.GetSection("JwtConfig");
            // in production
            // var Key = Environment.GetEnvironmentVariable("JWT_KEY")
            services.AddAuthentication(opt =>
            {
                // We are saying we are adding authentication to the application and the default scheme we are using
                // is Jwt
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;

                // We are saying whatever information comes in, challenge it base on the JWT scheme
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(opt =>
            {
                opt.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = jwtSettings.GetSection("Issuer").Value,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.GetSection("SecretKey").Value))
                };
            });
        }
    }
}
