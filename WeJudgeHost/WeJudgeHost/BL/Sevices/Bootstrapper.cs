using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using WeJudgeHost.BL.Dal;

namespace WeJudgeHost.BL.Sevices
{
    public static class Bootstrapper
    {
        internal static void Register(IServiceCollection services, IConfiguration configuration)
        {
            string connectionStr = configuration.GetValue<string>("Data:WeJudgeConnection:ConnectionString");
            services.AddDbContext<WeJadgeIdentityContext>(
                options => options.UseSqlServer(connectionStr));

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,

                    ValidIssuer = "http://localhost:5000",
                    ValidAudience = "http://localhost:5000",
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("nezabudumatrodnuu@592"))
                };
            });

            services.AddAutoMapper();
            services.AddMvc();
        }

    }
}
