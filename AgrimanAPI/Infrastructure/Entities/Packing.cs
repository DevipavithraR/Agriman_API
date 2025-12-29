namespace AgrimanAPI.Infrastructure.Entities
{
    public class Packing
    {
        public int Id { get; set; }            // PK, Auto Increment
        public string? PackingName { get; set; } // packing_name
        public int Unit { get; set; }           // unit
        public int UnitAmount { get; set; }     // unit_amount
    }
}

