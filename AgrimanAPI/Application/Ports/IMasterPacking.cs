using AgrimanAPI.Infrastructure.Entities;

namespace AgrimanAPI.Application.Ports
{
    public interface IMasterPacking
    {
        Task<List<PackingEntity>> GetAllAsync();
    }
}
