using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Loto.Infrastructure.Context;

namespace Loto.IOC.Dependencies
{
    public static class ContextDependency
    {
        public static void AddContextDependency(this IServiceCollection services, string connString) 
        {
            services.AddDbContext<LotoContext>(options => options.UseSqlServer(connString));
        }
    }
}
