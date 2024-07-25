using DataExporter.Application.AutoMapper;
using DataExporter.Application.Implementations;
using DataExporter.Application.Interfaces;
using DataExporter.Domain.Repositories;
using DataExporter.Infrastructure;
using DataExporter.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DataExporter
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Logging.ClearProviders();
            builder.Logging.AddConsole();

            builder.Services.AddControllers();

            builder.Services.AddAutoMapper(typeof(AutoMapperProfilesConfig).Assembly);

            builder.Services.AddDbContext<ExporterDbContext>(options => 
                options.UseInMemoryDatabase("ExporterDb"));

            builder.Services.AddScoped<IPolicyRepository, PolicyRepository>();
            builder.Services.AddScoped<IPolicyService, PolicyService>();

            var app = builder.Build();

            using (var scope = app.Services.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<ExporterDbContext>();
                dbContext.Database.EnsureCreated();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
