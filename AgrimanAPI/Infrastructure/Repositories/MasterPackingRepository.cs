using AgrimanAPI.Application.Ports;
using AgrimanAPI.Infrastructure.Data;
using AgrimanAPI.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace AgrimanAPI.Infrastructure.Repositories
{
    public class MasterPackingRepository:IMasterPacking
    {
        private readonly AppDbContext _db;
        public MasterPackingRepository(AppDbContext db)
        {
            _db = db;
        }

        public async Task<List<PackingEntity>> GetAllAsync()
        {
            return await _db.PackingsEntity.ToListAsync();
        }
    }
}
