using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RetroCSV.Core.Interfaces;
using RetroCSV.Core.Interfaces.Persistence;
using RetroCSV.Infrastructure.Persistence;
using RetroCSV.Infrastructure.Persistence.Repositories;
using RetroCSV.Infrastructure.Services;
using RetroCSV.Infrastructure.Services.SystemClock;

namespace RetroCSV.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options => options.UseInMemoryDatabase("Database"));
            services.AddScoped(typeof(IAsyncRepository<>), typeof(BaseRepository<>));
            services.AddScoped<IBoardsRepository, BoardsRepository>();
            services.AddScoped<IDateTime, DateTimeService>();
            return services;
        }
    }
}