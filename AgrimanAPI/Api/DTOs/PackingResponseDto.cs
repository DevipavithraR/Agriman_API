namespace AgrimanAPI.Api.DTOs
{
    public class PackingResponseDto
    {
        public int Id { get; internal set; }
        public string PackingName { get; set; }
        public int Unit { get; set; }
        public int UnitAmount { get; set; }
        
    }
}
