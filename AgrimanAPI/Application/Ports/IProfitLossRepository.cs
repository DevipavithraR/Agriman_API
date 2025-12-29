namespace AgrimanAPI.Application.Ports
{
    public interface IProfitLossRepository
    {
        Task<bool> WorkExistsAsync(int workId);
        Task<bool> ThingsExistsAsync(int thingsId);

        Task<decimal> GetWorkTotalAsync(int workId);
        Task<decimal> GetThingsTotalAsync(int thingsId);
        Task<decimal> GetPackingTotalAsync(int workId);

        Task SaveAsync(AgrimanAPI.Domain.ProfitLoss profitLoss);
    }
}
