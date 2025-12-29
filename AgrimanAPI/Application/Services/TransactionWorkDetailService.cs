using AgrimanAPI.Application.Ports;
using AgrimanAPI.Domain;

namespace Agriman.Application.Services
{
    public class TransactionWorkDetailService
    {
        private readonly ITransactionWorkDetailRepository _repository;
        public TransactionWorkDetailService(ITransactionWorkDetailRepository repository)
        {
            _repository = repository;
        }

        public Task<TransactionWorkDetail> CreateAsync(TransactionWorkDetail domain)
            => _repository.AddAsync(domain);

        public Task<TransactionWorkDetail?> GetByIdAsync(int id)
            => _repository.GetByIdAsync(id);

        public Task<List<TransactionWorkDetail>> GetAllAsync()
            => _repository.GetAllAsync();

        public Task<bool> UpdateAsync(TransactionWorkDetail domain)
            => _repository.UpdateAsync(domain);

        public Task<bool> DeleteAsync(int id)
            => _repository.DeleteAsync(id);
    }
}
