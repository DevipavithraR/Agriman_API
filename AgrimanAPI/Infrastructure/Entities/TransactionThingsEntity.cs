using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AgrimanAPI.Domain;

namespace AgrimanAPI.Infrastructure.Entities;

[Table("transaction_things_details")]
public class TransactionThingsEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [ForeignKey(nameof(ThingsId))]
    [Column("things_id")]
    public int ThingsId { get; set; }


    [Column("things_name")]
    public string ThingsName { get; set; }

    [Column("thing_quantity")]
    public int ThingQuantity { get; set; }

    [Column("amount_spend")]
    public float AmountSpend { get; set; }

    public TransactionThings ToDomain()
        => TransactionThings.Load(
            Id,
            ThingsId,
            ThingsName,
            ThingQuantity,
            AmountSpend);

    public static TransactionThingsEntity FromDomain(TransactionThings domain)
        => new()
        {
            Id = domain.Id,
            ThingsId = domain.ThingsId,
            ThingsName = domain.ThingsName,
            ThingQuantity = domain.ThingQuantity,
            AmountSpend = domain.AmountSpend
        };
}
