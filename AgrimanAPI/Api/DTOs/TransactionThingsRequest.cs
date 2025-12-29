using AgrimanAPI.Domain;

namespace AgrimanAPI.DTOs;

public class TransactionThingsRequest
{
    public int ThingsId { get; set; }

    public string ThingsName { get; set; }
    public int ThingQuantity { get; set; }
    public float AmountSpend { get; set; }

    // DTO → Domain
    public TransactionThings ToDomain()
        => TransactionThings.Create(
            ThingsId,
            ThingsName,
            ThingQuantity,
            AmountSpend);
}
