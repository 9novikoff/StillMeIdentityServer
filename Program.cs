using Microsoft.AspNetCore.Identity;

namespace StillMeIdentityServer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var app = builder.Build();

            app.Run();
        }
    }
}