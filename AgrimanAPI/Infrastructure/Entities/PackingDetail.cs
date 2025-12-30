namespace AgrimanAPI.Infrastructure.Entities
{
    public class PackingDetail
    {
        public int Id { get; set; }              // PK, Auto Increment
        public int PackingId { get; set; }       // FK -> Packing.Id
        public required string PackingName { get; set; }
        public int NumberOfUnits { get; set; }
        public float UnitAmount { get; set; }    // <-- Add this line
        
    }
}

