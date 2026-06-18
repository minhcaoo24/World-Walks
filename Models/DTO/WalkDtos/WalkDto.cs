using WorldWalks.Models.DTO.RegionDtos;
using WorldWalks.Models.DTO.DifficultyDtos;

namespace WorldWalks.Models.DTO.WalkDtos;
#pragma warning disable CS8618
public class WalkDto
{
    public Guid Id { get; set; }
    public string? HikerName { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public double LengthInKm { get; set; }
    
    //Navigation Properties
    public RegionDto Region { get; set; }
    public DifficultyDto Difficulty { get; set; }
}
#pragma warning restore CS8618