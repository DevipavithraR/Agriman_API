using System.ComponentModel.DataAnnotations.Schema;
using AgrimanAPI.Domain;

namespace AgrimanAPI.Infrastructure.Entities
{
    [Table("Transaction_Work_Details")]
    public class TransactionWorkDetailEntity
    {
        public int Id { get; set; }
        public int WorkId { get; set; }
        //public string WorkName { get; set; } = null!;
        public string? WorkName { get; set; }


        public int WorkersCount { get; set; }
        public decimal Amount { get; set; } // ✅ FIXED

        public static TransactionWorkDetailEntity FromDomain(TransactionWorkDetail domain)
            => new TransactionWorkDetailEntity
            {
                Id = domain.Id,
                WorkId = domain.WorkId,
                WorkName = domain.WorkName,
                WorkersCount = domain.WorkersCount,
                Amount = domain.Amount
            };

        public TransactionWorkDetail ToDomain()
            => new TransactionWorkDetail(Id, WorkId, WorkName, WorkersCount, Amount);
    }
}
