using Microsoft.EntityFrameworkCore;
using AgrimanAPI.Application.Ports;
using AgrimanAPI.Domain;
using AgrimanAPI.Infrastructure.Data;
using AgrimanAPI.Infrastructure.Entities;

namespace AgrimanAPI.Infrastructure.Repositories;

public class TransactionThingsRepository : ITransactionThingsRepository
{
    private readonly AppDbContext _context;

    public TransactionThingsRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<TransactionThings>> GetAllAsync()
        => await _context.TransactionThingsEntity
            .Select(e => e.ToDomain())
            .ToListAsync();

    public async Task<TransactionThings?> GetByIdAsync(int id)
        => (await _context.TransactionThingsEntity.FindAsync(id))?.ToDomain();

    public async Task<TransactionThings> CreateAsync(TransactionThings domain)
    {
        var entity = TransactionThingsEntity.FromDomain(domain);
        _context.TransactionThingsEntity.Add(entity);
        await _context.SaveChangesAsync();
        return entity.ToDomain();
    }

    public async Task<TransactionThings?> UpdateAsync(TransactionThings domain)
    {
        var entity = await _context.TransactionThingsEntity.FindAsync(domain.Id);
        if (entity == null) return null;

        entity.ThingsId = domain.ThingsId;
        entity.ThingQuantity = domain.ThingQuantity;
        entity.AmountSpend = domain.AmountSpend;

        await _context.SaveChangesAsync();
        return entity.ToDomain();
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var entity = await _context.TransactionThingsEntity.FindAsync(id);
        if (entity == null) return false;

        _context.TransactionThingsEntity.Remove(entity);
        await _context.SaveChangesAsync();
        return true;
    }
}
