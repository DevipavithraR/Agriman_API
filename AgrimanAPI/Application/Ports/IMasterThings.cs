using AgrimanAPI.Infrastructure.Entities;

namespace AgrimanAPI.Application.Ports
{
    public interface IMasterThings
    {
        Task<List<AgriThingEntity>> GetAllAsync();
    }
}
