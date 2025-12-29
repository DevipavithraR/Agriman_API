using AgrimanAPI.Application.Ports;
using AgrimanAPI.Domain;
using AgrimanAPI.Infrastructure.Data;
using AgrimanAPI.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;


namespace AgrimanAPI.Infrastructure.Repositories
{
    public class TransactionWorkDetailRepository : ITransactionWorkDetailRepository
    {
        private readonly AppDbContext _db;
        public TransactionWorkDetailRepository(AppDbContext db)
        {
            _db = db;
        }

        public async Task<TransactionWorkDetail> AddAsync(TransactionWorkDetail domain)
        {
            var entity = TransactionWorkDetailEntity.FromDomain(domain);
            _db.TransactionWorkDetails.Add(entity);
            await _db.SaveChangesAsync();
            return entity.ToDomain();
        }

        public async Task<TransactionWorkDetail?> GetByIdAsync(int id)
        {
            var entity = await _db.TransactionWorkDetails.FindAsync(id);
            return entity?.ToDomain();
        }

        public async Task<List<TransactionWorkDetail>> GetAllAsync()
        {
            return await _db.TransactionWorkDetails
                .Select(e => e.ToDomain())
                .ToListAsync();
        }

        public async Task<bool> UpdateAsync(TransactionWorkDetail domain)
        {
            // 1️⃣ Load the existing entity (TRACKED)
            var entity = await _db.TransactionWorkDetails
                .FirstOrDefaultAsync(x => x.Id == domain.Id);

            if (entity == null)
                return false;

            // 2️⃣ Assign values explicitly
            entity.WorkId = domain.WorkId;
            entity.WorkName = domain.WorkName;   // ✅ THIS WAS NEVER TRACKED BEFORE
            entity.WorkersCount = domain.WorkersCount;
            entity.Amount = domain.Amount;

            // 3️⃣ Save
            await _db.SaveChangesAsync();
            return true;
        }


        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _db.TransactionWorkDetails.FindAsync(id);
            if (entity == null) return false;

            _db.TransactionWorkDetails.Remove(entity);
            await _db.SaveChangesAsync();
            return true;
        }
    }
}
