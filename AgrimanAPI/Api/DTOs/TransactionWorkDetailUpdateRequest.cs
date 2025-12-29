using AgrimanAPI.Domain;

namespace AgrimanAPI.Api.DTOs
{
    public class TransactionWorkDetailUpdateRequest
    {
        public int Id { get; set; }
        public int WorkId { get; set; }
        public string WorkName { get; set; }


        public int WorkersCount { get; set; }
        public decimal Amount { get; set; }

        public TransactionWorkDetail ToDomain(int id)
        {
            return new TransactionWorkDetail
            {
                Id = id,
                WorkId = this.WorkId,
                WorkName = this.WorkName,
                WorkersCount = this.WorkersCount,
                Amount = this.Amount
            };
        }

    }

}