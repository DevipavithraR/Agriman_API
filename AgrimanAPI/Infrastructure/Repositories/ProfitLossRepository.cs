using AgrimanAPI.Application.Ports;
using AgrimanAPI.Domain;
using AgrimanAPI.Infrastructure.Data;
using AgrimanAPI.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace AgrimanAPI.Infrastructure.Repositories
{
    public class ProfitLossRepository : IProfitLossRepository
    {
        private readonly AppDbContext _context;

        public ProfitLossRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<bool> WorkExistsAsync(int workId) =>
            await _context.AgriWorks.AnyAsync(x => x.Id == workId);

        public async Task<bool> ThingsExistsAsync(int thingsId) =>
            await _context.AgriThings.AnyAsync(x => x.Id == thingsId);

        public async Task<bool> PackingExistsAsync(int packingId) =>
            await _context.PackingTransactions.AnyAsync(x => x.Id == packingId);

        public async Task<decimal> GetWorkTotalAsync(int workId) =>
            await _context.TransactionWorkDetails
                .Where(x => x.WorkId == workId)
                .SumAsync(x => (decimal?)x.Amount) ?? 0;

        public async Task<decimal> GetThingsTotalAsync(int thingsId) =>
            await _context.TransactionThingsEntity
                .Where(x => x.ThingsId == thingsId)
                .SumAsync(x => (decimal?)x.AmountSpend) ?? 0;

        public async Task<decimal> GetPackingTotalAsync(int packingId) =>
            await _context.PackingTransactions
                 .Where(x => x.PackingId == packingId)
                 .SumAsync(x => (decimal?)(x.NumberOfUnits * x.UnitAmount)) ?? 0;



        public async Task SaveAsync(ProfitLoss profitLoss)
        {
            var entity = new ProfitLossEntity
            {
                WorkId = profitLoss.WorkId,
                ThingsId = profitLoss.ThingsId,
                PackingId = profitLoss.PackingId,
                WorkTotalAmount = profitLoss.WorkTotal,
                ThingsTotalAmount = profitLoss.ThingsTotal,
                PackingTotalAmount = profitLoss.PackingTotal,
                ProfitOrLoss = profitLoss.ProfitOrLoss
            };

            _context.ProfitLossDetails.Add(entity);
            await _context.SaveChangesAsync();
        }
    }
}
