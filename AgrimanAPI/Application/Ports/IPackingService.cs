using AgrimanAPI.Api.DTOs;
using AgrimanAPI.Infrastructure.Entities;

namespace AgrimanAPI.Application.Ports
{
    public interface IPackingService
    {
        Task<IEnumerable<Packing>> GetAllAsync();
        Task AddAsync(PackingDto packingDto);
        Task AddDetailAsync(PackingDetailDto detailDto);
    }
}
