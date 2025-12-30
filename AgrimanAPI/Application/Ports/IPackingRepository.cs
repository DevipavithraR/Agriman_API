using AgrimanAPI.Infrastructure.Entities;

namespace AgrimanAPI.Application.Ports
{
    public interface IPackingRepository
    {
        Task<List<PackingDetail>> GetAllAsync();
        Task<PackingDetail> AddAsync(PackingDetail packingDetail);
        Task<PackingEntity?> GetPackingByIdAsync(int packingId);
    }
}
