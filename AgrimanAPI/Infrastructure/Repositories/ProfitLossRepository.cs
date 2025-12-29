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

        public async Task<decimal> GetWorkTotalAsync(int workId) =>
            await _context.TransactionWorkDetails
                .Where(x => x.WorkId == workId)
                .SumAsync(x => x.Amount);

        public async Task<decimal> GetThingsTotalAsync(int thingsId)
        {
            return (decimal)await _context.TransactionThingsEntity
              .Where(x => x.ThingsId == thingsId)
         .SumAsync(x => x.AmountSpend);
        }

        public async Task<decimal> GetPackingTotalAsync(int workId)
        {
            return (decimal)await _context.PackingTransactions
                .Where(x => x.WorkId == workId)
                .SumAsync(x => x.NumberOfUnits * x.UnitAmount);
        }

        public async Task SaveAsync(AgrimanAPI.Domain.ProfitLoss profitLoss)
        {
            var entity = new ProfitLossEntity
            {
                WorkId = profitLoss.WorkId,
                ThingsId = profitLoss.ThingsId,
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
