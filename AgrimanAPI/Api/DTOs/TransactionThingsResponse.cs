using AgrimanAPI.Domain;

namespace AgrimanAPI.DTOs;

public class TransactionThingsResponse
{
    public int Id { get; set; }
    public int ThingsId { get; set; }
    public string ThingsName { get; set; }

    public int ThingQuantity { get; set; }
    public float AmountSpend { get; set; }

    // Domain → DTO
    public static TransactionThingsResponse FromDomain(TransactionThings domain)
        => new()
        {
            Id = domain.Id,
            ThingsId = domain.ThingsId,
            ThingsName = domain.ThingsName,
            ThingQuantity = domain.ThingQuantity,
            AmountSpend = domain.AmountSpend
        };
}
