using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using CP3.Data.AppData;
using CP3.Data.Repositories;
using CP3.Domain.Interfaces.Repositories;
using CP3.Application.Services;
using CP3.Application.Interfaces;

namespace CP3.IoC
{
    public static class Bootstrap
    {
        public static void Start(IServiceCollection services, IConfiguration configuration)
        {
            
            services.AddDbContext<ApplicationContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            
            services.AddScoped<IBarcoRepository, BarcoRepository>();
            services.AddScoped<IBarcoService, BarcoService>();

            
        }
    }
}
