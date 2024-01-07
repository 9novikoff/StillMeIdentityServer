using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace StillMeIdentityServer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddAuthentication().AddBearerToken(IdentityConstants.BearerScheme);

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