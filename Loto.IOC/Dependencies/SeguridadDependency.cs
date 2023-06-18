
using Microsoft.Extensions.DependencyInjection;
using Loto.Application.Contract;
using Loto.Application.Services;
using Loto.Infrastructure.Interfaces;
using Loto.Infrastructure.Repositories;

namespace Loto.IOC.Dependencies
{
    public static class SeguridadDependency
    {
        public static void AddSecurityDependency(this IServiceCollection services)
        {

            #region "Repositories"
            services.AddScoped<IRolRepository, RolRepository>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();

            #endregion

            #region "Services"
            services.AddTransient<IUsuarioService, UsuarioService>();
            #endregion

        }
    }
}
