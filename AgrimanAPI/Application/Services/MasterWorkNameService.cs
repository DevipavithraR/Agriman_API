using AgrimanAPI.Application.Ports;
using AgrimanAPI.Infrastructure.Entities;

namespace AgrimanAPI.Application.Services
{
    public class MasterWorkNameService
    {
        private readonly IMasterWorkNames _repository;
        public MasterWorkNameService(IMasterWorkNames repository)
        {
            _repository = repository;
        }

       public Task<List<AgriWorkEntity>> GetAllAsync()
            => _repository.GetAllAsync();
    }
}
