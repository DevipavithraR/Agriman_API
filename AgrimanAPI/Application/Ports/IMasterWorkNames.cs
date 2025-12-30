using AgrimanAPI.Infrastructure.Entities;

namespace AgrimanAPI.Application.Ports
{
    public interface IMasterWorkNames
    {
        Task<List<AgriWorkEntity>> GetAllAsync();

    }
}
