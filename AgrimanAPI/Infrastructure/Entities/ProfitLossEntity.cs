using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AgrimanAPI.Infrastructure.Entities
{
    [Table("profit_loss_details")]
    public class ProfitLossEntity
    {
        [Key]
        public int Id { get; set; }

        public int WorkId { get; set; }

        public int ThingsId { get; set; }
        public int PackingId { get; set; }


        public decimal WorkTotalAmount { get; set; }

        public decimal ThingsTotalAmount { get; set; }

        public decimal PackingTotalAmount { get; set; }

        public decimal ProfitOrLoss { get; set; }   // ✅ REQUIRED
    }
}
