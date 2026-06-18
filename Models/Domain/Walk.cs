namespace WorldWalks.Models.Domain;
#pragma warning disable CS8618
public class Walk
{
    public Guid Id { get; set; }
    public string? HikerName { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }
    public double LengthInKm { get; set; }

    public Guid DifficultyId { get; set; }
    public Guid RegionId { get; set; }

    //Navigation props
    public Difficulty Difficulty { get; set; }
    public Region Region { get; set; }
}
#pragma warning restore CS8618