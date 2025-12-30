using AgrimanAPI.Application.Ports;
using AgrimanAPI.Infrastructure.Data;
using AgrimanAPI.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace AgrimanAPI.Infrastructure.Repositories
{
    public class MasterWorkNameRepository : IMasterWorkNames
    {
        private readonly AppDbContext _db;
        public MasterWorkNameRepository(AppDbContext db)
        {
            _db = db;
        }

        public async Task<List<AgriWorkEntity>> GetAllAsync()
        {
            return await _db.AgriWorks.ToListAsync();
        }
    }
}
