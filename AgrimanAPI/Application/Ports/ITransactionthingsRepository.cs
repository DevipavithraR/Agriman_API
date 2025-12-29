using AgrimanAPI.Domain;

namespace AgrimanAPI.Application.Ports;

public interface ITransactionThingsRepository
{
    Task<IEnumerable<TransactionThings>> GetAllAsync();
    Task<TransactionThings?> GetByIdAsync(int id);
    Task<TransactionThings> CreateAsync(TransactionThings domain);
    Task<TransactionThings> UpdateAsync(TransactionThings domain);
    Task<bool> DeleteAsync(int id);
}
