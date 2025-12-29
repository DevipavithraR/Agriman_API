namespace AgrimanAPI.Domain;

public sealed class TransactionThings
{
    public int Id { get; }
    public int ThingsId { get; }
    public string ThingsName { get; } = null!;

    public int ThingQuantity { get; }
    public float AmountSpend { get; }

    private TransactionThings(int id, int thingsId, string thingsName,int thingQuantity, float amountSpend)
    {
        Id = id;
        ThingsId = thingsId;
        ThingsName = thingsName;
        ThingQuantity = thingQuantity;
        AmountSpend = amountSpend;
    }

    public static TransactionThings Create(int thingsId, string thingsName,int thingQuantity, float amountSpend)
        => new(0, thingsId,  thingsName, thingQuantity, amountSpend);

    public static TransactionThings Load(int id, int thingsId, string thingsName, int thingQuantity, float amountSpend)
        => new(id, thingsId,  thingsName, thingQuantity, amountSpend);
}
