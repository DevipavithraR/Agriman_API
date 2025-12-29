using System.ComponentModel.DataAnnotations;

namespace AgrimanAPI.Api.DTOs;

public class PackingDto
{
    [Required]
    public string PackingName { get; set; }

    [Range(1, int.MaxValue)]
    public int Unit { get; set; }

    [Range(1, int.MaxValue)]
    public int UnitAmount { get; set; }
}

