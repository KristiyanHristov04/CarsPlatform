using CarsPlatform.Application.Contracts;
using CarsPlatform.Core.Entities;
using CarsPlatform.Infrastructure.Data;
using CarsPlatform.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Identity;

namespace CarsPlatform.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<CarsPlatformDbContext>(options =>
                options.UseSqlServer(connectionString));

            services.AddDefaultIdentity<User>(options =>
            {
                options.SignIn.RequireConfirmedAccount = false;
            })
                .AddEntityFrameworkStores<CarsPlatformDbContext>();

            services.AddScoped<ICsvDataReader, CsvDataReader>();
            services.AddScoped<ICarService, CarService>();
            services.AddScoped<IAPICarService, APICarService>();
            services.AddScoped<ICarStatisticsService, CarStatisticsService>();

            return services;
        }
    }
}
