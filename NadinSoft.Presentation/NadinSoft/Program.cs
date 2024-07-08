
using Microsoft.EntityFrameworkCore;
using NadinSoft.Data.Context;
using NadinSoft.IOC.Dependencies;
using System;

namespace NadinSoft
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
            builder.Services.AddSwaggerGen();
            //IOC Layer Dependency Service
            builder.Services.ServicesDependencies();

            //DBContext Dependency
            builder.Services.AddDbContext<NadinSoftContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }


            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.Services.CreateScope().ServiceProvider.GetRequiredService<NadinSoftContext>();

            app.MapControllers();
            //Automatic creating DataBase
            using (var scope = app.Services.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<NadinSoftContext>();
                dbContext.Database.EnsureCreated();
            }

            app.Run();
        }
    }
}
