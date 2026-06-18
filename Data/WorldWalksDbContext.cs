using Microsoft.EntityFrameworkCore;
using WorldWalks.Models.Domain;

namespace WorldWalks.Data;

public class WorldWalksDbContext : DbContext
{
    public WorldWalksDbContext(DbContextOptions<WorldWalksDbContext> opts) : base(opts) { }

    public DbSet<Walk> Walks { get; set; }
    public DbSet<Difficulty> Difficulties { get; set; }
    public DbSet<Region> Regions { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        var difficulty = new List<Difficulty>()
        {
            new Difficulty()
            {
                Id = Guid.Parse("b1165848-9b75-4650-a742-ff3fbff79a61"),
                Status = "Easy"
            },
            new Difficulty()
            {
                Id = Guid.Parse("5fdc857e-016d-46f1-b069-35a6ca94595f"),
                Status = "Medium"
            },
            new Difficulty()
            {
                Id = Guid.Parse("68a7f624-b174-480a-bda6-00e6d95b1285"),
                Status = "Hard"
            }
        };

        var regions = new List<Region>
        {
            new()
            {
                Id = Guid.Parse("7f3c8c11-9c5f-41db-9e4d-bd45efc78121"),
                Code = "AKL",
                Name = "Auckland",
                RegionImageUrl = "https://example.com/region1.jpg"
            },
            new()
            {
                Id = Guid.Parse("1a8f4cb2-41ad-44c0-8dd1-2cc14856e4bb"),
                Code = "WLG",
                Name = "Wellington",
                RegionImageUrl = "https://example.com/region2.jpg"
            },
            new()
            {
                Id = Guid.Parse("e29bdc8c-b2df-48b4-9eb7-0da3e7cf5c9c"),
                Code = "CHC",
                Name = "Christchurch",
                RegionImageUrl = "https://example.com/region3.jpg"
            },
            new()
            {
                Id = Guid.Parse("a5c044b6-29ea-4e20-b59e-7e7efca067d3"),
                Code = "DND",
                Name = "Dunedin",
                RegionImageUrl = "https://example.com/region4.jpg"
            },
            new()
            {
                Id = Guid.Parse("bb3a9cbe-cce3-4be3-b836-94dbb54c0f7d"),
                Code = "NSN",
                Name = "Nelson",
                RegionImageUrl = "https://example.com/region5.jpg"
            },
            new()
            {
                Id = Guid.Parse("6fba3df7-6453-47d0-9844-9df0f08d2441"),
                Code = "TOS",
                Name = "Tasman",
                RegionImageUrl = "https://example.com/region6.jpg"
            },
            new()
            {
                Id = Guid.Parse("fc0b3800-9e0a-4d4b-b165-a05a1ba1cbe5"),
                Code = "BOP",
                Name = "Bay of Plenty",
                RegionImageUrl = "https://example.com/region7.jpg"
            },
            new()
            {
                Id = Guid.Parse("d84ddc36-d8cd-4737-8dee-397a093c8d06"),
                Code = "WKO",
                Name = "Waikato",
                RegionImageUrl = "https://example.com/region8.jpg"
            },
            new()
            {
                Id = Guid.Parse("ad3ee423-2e06-463d-b99e-7e09bc9e6ffe"),
                Code = "NTL",
                Name = "Northland",
                RegionImageUrl = "https://example.com/region9.jpg"
            },
            new()
            {
                Id = Guid.Parse("57c7a9ff-ea12-4df1-a5d1-dcd6730fb158"),
                Code = "GIS",
                Name = "Gisborne",
                RegionImageUrl = "https://example.com/region10.jpg"
            }
        };

        //Seed data for difficulty
        modelBuilder.Entity<Difficulty>().HasData(difficulty);
        modelBuilder.Entity<Region>().HasData(regions);
    }
}