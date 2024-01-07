using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Configuration;

namespace StillMeIdentityServer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(JwtBearerDefaults.AuthenticationScheme);
            builder.Services.AddAuthorizationBuilder();

            builder.Services.AddDbContext<IdentityDbContext>(options => 
                                                            options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

            builder.Services.AddIdentityCore<User>()
                            .AddEntityFrameworkStores<IdentityDbContext>()
                            .AddApiEndpoints();

            var app = builder.Build();

            app.MapIdentityApi<User>();

            app.Run();
        }
    }
}