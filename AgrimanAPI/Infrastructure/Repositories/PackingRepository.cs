using AgrimanAPI.Application.Ports;
using AgrimanAPI.Infrastructure.Data;
using AgrimanAPI.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace AgrimanAPI.Infrastructure.Repositories
{
    public class PackingRepository : IPackingRepository
    {
        private readonly AppDbContext _context;

        public PackingRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<PackingDetail>> GetAllAsync()
        {
            return await _context.PackingTransactions.ToListAsync();
        }

        public async Task<PackingDetail> AddAsync(PackingDetail packingDetail)
        {
            _context.PackingTransactions.Add(packingDetail);
            await _context.SaveChangesAsync();
            return packingDetail;
        }

       
        public async Task<PackingEntity?> GetPackingByIdAsync(int packingId)
        {
            return await _context.PackingsEntity.FindAsync(packingId);
        }
    }
}
