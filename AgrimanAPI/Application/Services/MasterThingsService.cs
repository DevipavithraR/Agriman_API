using AgrimanAPI.Application.Ports;
using AgrimanAPI.Infrastructure.Entities;

namespace AgrimanAPI.Application.Services
{
    public class MasterThingsService
    {
        private readonly IMasterThings _repository;
        public MasterThingsService(IMasterThings repository)
        {
            _repository = repository;
        }
        public Task<List<AgriThingEntity>> GetAllAsync()
        => _repository.GetAllAsync();
    }
}


