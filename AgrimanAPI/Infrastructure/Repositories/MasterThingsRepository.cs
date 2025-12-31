using AgrimanAPI.Application.Ports;
using AgrimanAPI.Infrastructure.Data;
using AgrimanAPI.Infrastructure.Entities;
using AgrimanAPI.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace AgrimanAPI.Infrastructure.Repositories
{
    public class MasterThingsRepository:IMasterThings
    {
        private readonly AppDbContext _db;
        public MasterThingsRepository(AppDbContext db)
        {
            _db = db;
        }

        public async Task<List<AgriThingEntity>> GetAllAsync()
        {
            return await _db.AgriThings.ToListAsync();
        }
    }
}

