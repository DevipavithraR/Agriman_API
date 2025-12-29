using AgrimanAPI.Domain;

namespace AgrimanAPI.Api.DTOs
{
    public class TransactionThingsUpdateRequest
    {
        public int ThingQuantity { get; set; }
        public float AmountSpend { get; set; }

        public TransactionThings ToDomain(
            int id,
            int thingsId,
            string thingsName)
        {
            return TransactionThings.Load(
                id,
                thingsId,
                thingsName,
                ThingQuantity,
                AmountSpend);
        }
    }
}
