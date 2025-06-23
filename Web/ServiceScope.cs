using Application.Repositories;
using Application.Services;
using Domain.RepositoryInterfaces;
using Domain.ServiceInterfaces;
using Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
namespace Web
{
    public static class ServiceScope
    {
        public static void ConfigureServices(this IServiceCollection services)
        {           

            #region Services
            services.AddScoped<IInventoryService, InventoryService>();
            services.AddScoped<IInventoryTypeService, InventoryTypeService>();
            #endregion

            #region Reposiroty
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IInventoryRepository, InventoryRepository>();
            services.AddScoped<IInventoryTypeRepository, InventoryTypeRepository>();
            #endregion
        }
    }
}
