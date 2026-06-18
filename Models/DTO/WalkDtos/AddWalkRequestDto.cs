using System.ComponentModel.DataAnnotations;

namespace WorldWalks.Models.DTO.WalkDtos;
#pragma warning disable CS8618
public class AddWalkRequestDto
{
    public string? HikerName { get; set; }
    [Required]
    [MaxLength(100, ErrorMessage = "Name has to be a maximum of 100 characters")]
    public string Name { get; set; }
    public string? Description { get; set; }
    [Required]
    [Range(0, 100)]
    public double LengthInKm { get; set; }

    [Required]
    public Guid DifficultyId { get; set; }
    [Required]
    public Guid RegionId { get; set; }
}
#pragma warning restore CS8618