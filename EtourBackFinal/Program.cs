
using EtourBackFinal.Model;
using Microsoft.EntityFrameworkCore;

namespace EtourBackFinal
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
            var b = builder.Configuration.GetConnectionString("Path");
            builder.Services.AddDbContext<ETourContext>((op) => op.UseSqlServer(b));
            builder.Services.AddCors((p) => p.AddDefaultPolicy(
                                    policy => policy.WithOrigins("*").
                                               AllowAnyHeader()
                                                  .AllowAnyMethod()
                                                  )//allow any method i.e it will let any method hit our server
            );

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.UseCors();
            app.MapControllers();

            app.Run();
        }
    }
}