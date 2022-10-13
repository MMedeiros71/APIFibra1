using APIFibra.Data;
using APIFibra.Entities;
using APIFibra.Interfaces;
using APIFibra.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace APIFibra.Extensions
{
    public static class ApplicationServicesExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, 
            IConfiguration configuration)
        {
            services.AddScoped<ITokenService, TokenService>();
            
            services.AddScoped<NoticiaRepository>();

            services.AddScoped<AtivoRepository>();
            
            services.AddScoped<CotaIndiceRepository>();

            services.AddScoped<CotaRepository>();

            services.AddScoped<RecadastroRepository>();
            
            services.AddDbContext<DataContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });

            return services;
        }
    }
}