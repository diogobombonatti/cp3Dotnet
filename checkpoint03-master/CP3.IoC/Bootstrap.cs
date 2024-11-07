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
            // Configuração do banco de dados com a string de conexão
            services.AddDbContext<ApplicationContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            // Registro de repositórios e serviços
            services.AddScoped<IBarcoRepository, BarcoRepository>();
            services.AddScoped<IBarcoService, BarcoService>();

            // Adicione outros serviços ou repositórios aqui, se necessário
        }
    }
}
