using System.Text.Json.Serialization;
using ClientDemoAngular.Server.DataBase.Context;
using ClientDemoAngular.Server.DataBase.Repositories;
using ClientDemoAngular.Server.Domain.Entities;
using ClientDemoAngular.Server.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ClientDemoAngular.Server
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            var connectionString = builder.Configuration["ConnectionStrings:DefaultConnStr"];
            builder.Services.AddControllers();
            builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString));
            builder.Services.AddDbContext<DbContext, AppDbContext>();

            builder.Services.AddScoped<IClientRepository, ClientRepository>();
            builder.Services.AddScoped<ISocialMediaRepository, SocialMediaRepository>();
            builder.Services.AddScoped<IClientTagRepository, ClientTagRepository>();
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("frontend", policy => policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
            });
            var app = builder.Build();
            app.UseCors("frontend");
            app.UseDefaultFiles();
            app.UseStaticFiles();

            // Configure the HTTP request pipeline.

            app.UseAuthorization();


            app.MapControllers();

            app.MapFallbackToFile("/index.html");

            app.Run();
        }
    }
}