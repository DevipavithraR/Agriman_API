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

        public async Task<IEnumerable<Packing>> GetAllAsync()
        {
            return await _context.Packings.ToListAsync();
        }

        public async Task AddAsync(Packing packing)
        {
            _context.Packings.Add(packing);
            await _context.SaveChangesAsync();
        }

        public async Task AddDetailAsync(PackingDetail packingDetail)
        {
            _context.PackingTransactions.Add(packingDetail);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> ExistsAsync(int packingId)
        {
            return await _context.Packings.AnyAsync(p => p.Id == packingId);
        }

        public async Task<Packing?> GetByIdAsync(int packingId)
        {
            return await _context.Packings.FindAsync(packingId);
        }
    }
}