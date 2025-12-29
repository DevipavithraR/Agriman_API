using AgrimanAPI.Infrastructure.Entities;

namespace AgrimanAPI.Application.Ports
{
    public interface IPackingRepository
    {
        Task<IEnumerable<Packing>> GetAllAsync();
        Task AddAsync(Packing packing);
        Task AddDetailAsync(PackingDetail packingDetail);

        // Check if packing exists (for foreign key validation)
        Task<bool> ExistsAsync(int packingId);

        // Get the Packing entity by ID (for unitAmount calculation)
        Task<Packing?> GetByIdAsync(int packingId);
    }
}

