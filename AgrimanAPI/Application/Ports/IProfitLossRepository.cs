using AgrimanAPI.Domain;

namespace AgrimanAPI.Application.Ports
{
    public interface IProfitLossRepository
    {
        Task<bool> WorkExistsAsync(int workId);
        Task<bool> ThingsExistsAsync(int thingsId);
        Task<bool> PackingExistsAsync(int packingId);

        Task<decimal> GetWorkTotalAsync(int workId);
        Task<decimal> GetThingsTotalAsync(int thingsId);
        Task<decimal> GetPackingTotalAsync(int packingId);

        Task SaveAsync(ProfitLoss profitLoss);
    }
}
