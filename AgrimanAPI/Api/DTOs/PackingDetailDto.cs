namespace AgrimanAPI.Api.DTOs;

public class PackingDetailDto
{
    public int PackingId { get; set; }
    public string? PackingName { get; set; } // optional
    public int NumberOfUnits { get; set; }
}
