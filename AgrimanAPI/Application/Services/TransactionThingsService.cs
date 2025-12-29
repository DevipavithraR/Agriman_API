using AgrimanAPI.Application.Ports;
using AgrimanAPI.Domain;

namespace AgrimanAPI.Application.Services
{
    public class TransactionThingsService
    {
        private readonly ITransactionThingsRepository _repository;

        public TransactionThingsService(ITransactionThingsRepository repository)
        {
            _repository = repository;
        }

        public Task<IEnumerable<TransactionThings>> GetAllAsync()
            => _repository.GetAllAsync();

        public Task<TransactionThings?> GetByIdAsync(int id)
            => _repository.GetByIdAsync(id);

        public Task<TransactionThings> CreateAsync(TransactionThings domain)
            => _repository.CreateAsync(domain);

        public Task<TransactionThings?> UpdateAsync(TransactionThings domain)
    => _repository.UpdateAsync(domain);



        public Task<bool> DeleteAsync(int id)
            => _repository.DeleteAsync(id);

        //internal async Task<bool> UpdateAsync(TransactionWorkDetail domain)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
