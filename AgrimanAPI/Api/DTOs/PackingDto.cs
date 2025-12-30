using System.ComponentModel.DataAnnotations;

namespace AgrimanAPI.Api.DTOs;

public class PackingDto
{
    public int packingId { get; set; } 
    public string PackingName { get; set; }

    
    public int Unit { get; set; }

 
    public int UnitAmount { get; set; }
}

