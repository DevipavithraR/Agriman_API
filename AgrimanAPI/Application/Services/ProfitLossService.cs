using AgrimanAPI.Api.DTOs;
using AgrimanAPI.Application.Ports;
using AgrimanAPI.Domain;

namespace AgrimanAPI.Application.Services
{
    public class ProfitLossService
    {
        private readonly IProfitLossRepository _repository;

        public ProfitLossService(IProfitLossRepository repository)
        {
            _repository = repository;
        }

        public async Task<ProfitLossResponse> CalculateAsync(int workId, int thingsId, object packingId)
        {
            // 1️⃣ Validate masters
            if (!await _repository.WorkExistsAsync(workId))
                throw new Exception("Work not found");

            if (!await _repository.ThingsExistsAsync(thingsId))
                throw new Exception("Things not found");

            // 2️⃣ Aggregate data
            var workTotal = await _repository.GetWorkTotalAsync(workId);
            var thingsTotal = await _repository.GetThingsTotalAsync(thingsId);
            var packingTotal = await _repository.GetPackingTotalAsync(workId);

            // 3️⃣ Validate transactions
            if (workTotal <= 0)
                throw new Exception("No work transactions found");

            if (thingsTotal <= 0)
                throw new Exception("No things transactions found");

            if (packingTotal <= 0)
                throw new Exception("No packing transactions found");

            // 4️⃣ Domain calculation
            var profitLoss = new ProfitLoss(
                workId,
                thingsId,
                workTotal,
                thingsTotal,
                packingTotal
            );

            // 5️⃣ Persist result
            await _repository.SaveAsync(profitLoss);

            // 6️⃣ Response
            return new ProfitLossResponse
            {
                WorkTotalAmount = workTotal,
                ThingsTotalAmount = thingsTotal,
                PackingTotalAmount = packingTotal,
                ProfitOrLoss = profitLoss.ProfitOrLoss,  // <-- fixed here
                Status = profitLoss.ProfitOrLoss > 0 ? "PROFIT"
                       : profitLoss.ProfitOrLoss < 0 ? "LOSS"
                       : "BREAK EVEN"
            };
        }
    }
}
