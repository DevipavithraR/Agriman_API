using AgrimanAPI.Domain;

namespace AgrimanAPI.Application.Ports
{
    public interface ITransactionWorkDetailRepository
    {
        Task<TransactionWorkDetail> AddAsync(TransactionWorkDetail domain);
        Task<TransactionWorkDetail?> GetByIdAsync(int id);
        Task<List<TransactionWorkDetail>> GetAllAsync();
        Task<bool> UpdateAsync(TransactionWorkDetail domain);
        Task<bool> DeleteAsync(int id);
    }
}
