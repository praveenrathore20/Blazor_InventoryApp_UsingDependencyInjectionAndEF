using Domain.RepositoryInterfaces;
using Infrastructure.Persistence.Contexts;
using Infrastructure.Persistence.Entities;
using Microsoft.Extensions.Configuration;

namespace Application.Repositories
{
    public class InventoryTypeRepository : Repository<ConfInventoryType>, IInventoryTypeRepository
    {
        private readonly IConfiguration _config;

        public InventoryTypeRepository(dbcontext context, IConfiguration config) : base(context)
        {
            _config = config;
        }
    }
}
