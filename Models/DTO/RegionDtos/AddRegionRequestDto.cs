using System.ComponentModel.DataAnnotations;

namespace WorldWalks.Models.DTO.RegionDtos;
#pragma warning disable CS8618
public class AddRegionRequestDto
{
    [Required]
    [MinLength(3, ErrorMessage = "Code has to be a minimum of 3 characters")]
    [MaxLength(3, ErrorMessage = "Code has to be a maximum of 3 characters")]
    public string Code { get; set; }
    [Required]
    [MaxLength(100, ErrorMessage = "Name has to be maximum of 100 characters")]
    public string Name { get; set; }
    public string? RegionImageUrl { get; set; }
}
#pragma warning restore