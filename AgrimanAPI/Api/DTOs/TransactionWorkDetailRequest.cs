using AgrimanAPI.Domain;

namespace AgrimanAPI.Api.DTOs
{
    public class TransactionWorkDetailRequest
    {
        public int WorkId { get; set; }
        public string WorkName { get; set; }

        public int WorkersCount { get; set; }
        public decimal Amount { get; set; }

        public TransactionWorkDetail ToDomain()
            => new TransactionWorkDetail(0, WorkId, WorkName, WorkersCount, Amount);
    }
}
