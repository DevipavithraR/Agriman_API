using AgrimanAPI.Application.Ports;
using AgrimanAPI.Infrastructure.Entities;

namespace AgrimanAPI.Application.Services
{
    public class MasterPackingService
    {
        private readonly IMasterPacking _repository;
        public MasterPackingService(IMasterPacking repository)
        {
            _repository = repository;
        }

        public Task<List<PackingEntity>> GetAllAsync()
             => _repository.GetAllAsync();
    }
}





