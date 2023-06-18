
using Microsoft.Extensions.DependencyInjection;
using Loto.Application.Contract;
using Loto.Application.Services;
using Loto.Infrastructure.Interfaces;
using Loto.Infrastructure.Repositories;


namespace Loto.IOC.Dependencies
{
    public static class BranchDependency
    {
        public static void AddBranchDependency(this IServiceCollection services) 
        {

            #region "Repositories"
            services.AddScoped<IBranchRepository, BranchRepository>();
            services.AddScoped<IGroupRepository, GroupRepository>();
            #endregion

            #region "Services"
            services.AddTransient<IBranchService, BranchService>();
            services.AddTransient<IGroupService, GroupService>();
            #endregion

        }
    }
}
