using AgrimanAPI.Api.DTOs;
using AgrimanAPI.Application.Ports;
using AgrimanAPI.Domain;


namespace AgrimanAPI.Api.DTOs
{
    public class ProfitLossResponse
    {
        public decimal WorkTotalAmount { get; set; }
        public decimal ThingsTotalAmount { get; set; }
        public decimal PackingTotalAmount { get; set; }
        public decimal ProfitOrLoss { get; set; }
        public string? Status { get; set; } // PROFIT / LOSS / BREAK EVEN
    }

}


