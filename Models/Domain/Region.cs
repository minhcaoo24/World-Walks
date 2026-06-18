namespace WorldWalks.Models.Domain;
#pragma warning disable CS8618
public class Region
{
    public Guid Id { get; set; }
    public string Code { get; set; }
    public string Name { get; set; }
    public string? RegionImageUrl { get; set; }
}
#pragma warning restore CS8618