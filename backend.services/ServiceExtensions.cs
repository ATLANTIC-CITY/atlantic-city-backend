
using backend.businesslogic.Interfaces.Maestros;
using backend.businesslogic.Maestros;
using Npgsql;
using System.Data;


using backend.repository.Interfaces.Maestros;
using backend.repository.Maestros;

using backend.repository.Interfaces.Prestamos;
using backend.businesslogic.Interfaces.Prestamo;
using backend.businesslogic.Prestamo;
using backend.repository.Prestamos;



namespace backend.services
{
    public static class ServiceExtensions
    {
        public static void ConfigureRepositoryManager(this IServiceCollection services, string connectionString)
        {
            services.AddScoped<IPersonaRepository, PersonaRepository>();
            services.AddScoped<IPrestamoRepository, PrestamoRepository>();
        }

        public static void ConfigureServicesManager(this IServiceCollection services)
        {
            services.AddScoped<IPersonaBL, PersonaBL>();
            services.AddScoped<IPrestamoBL, PrestamoBL>();
        }
    }
}
