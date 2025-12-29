namespace AgrimanAPI.Api.DTOs
{
    public class ProfitLossRequest
    {
        public int WorkId { get; set; }
        public int ThingsId { get; set; }
        public int PackingId { get; internal set; }
    }

}

