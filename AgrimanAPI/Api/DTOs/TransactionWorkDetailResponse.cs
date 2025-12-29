using AgrimanAPI.Domain;

namespace AgrimanAPI.Api.DTOs
{
    public class TransactionWorkDetailResponse
    {
        public int Id { get; set; }
        public int WorkId { get; set; }
        public string WorkName { get; set; }

        public int WorkersCount { get; set; }
        public decimal  Amount { get; set; }

        public static TransactionWorkDetailResponse FromDomain(TransactionWorkDetail domain)
            => new TransactionWorkDetailResponse
            {
                Id = domain.Id,
                WorkId = domain.WorkId,
                WorkName = domain.WorkName,
                WorkersCount = domain.WorkersCount,
                Amount = domain.Amount
            };
    }
}
