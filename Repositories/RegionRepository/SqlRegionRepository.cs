using Microsoft.EntityFrameworkCore;
using WorldWalks.Data;
using WorldWalks.Models.Domain;

namespace WorldWalks.Repositories.RegionRepository;

public class SqlRegionRepository : IRegionRepository
{
    private readonly WorldWalksDbContext _dbContext;
    public SqlRegionRepository(WorldWalksDbContext dbContext)
    {
        this._dbContext = dbContext;
    }

    public async Task<List<Region>> GetAllAsync()
    {
        try
        {
            var regions = await _dbContext.Regions.ToListAsync();
            if(regions == null)
            {
                throw new Exception($"Không có dữ liệu trong database - TABLE Walk");
            }
            return regions;
        }
        catch (Exception e)
        {
            throw new Exception(message: $"ERROR: {e.Message}");
        }
    }

    public async Task<Region?> GetByIdAsync(Guid id)
    {
        try
        {
            var region = await _dbContext.Regions.FirstOrDefaultAsync(x => x.Id == id);
            if (region == null)
            {
                throw new Exception(message: $"Không tìm thấy region");
            }
            return region;
        }
        catch (Exception e)
        {
            throw new Exception(message: $"ERROR: {e.Message}");
        }
    }

    public async Task<Region> CreateAsync(Region region)
    {
        await _dbContext.Regions.AddAsync(region);
        await _dbContext.SaveChangesAsync();
        return region;
    }

    public async Task<Region?> UpdateAsync(Guid id, Region region)
    {
        try
        {
            var r = await _dbContext.Regions.FirstOrDefaultAsync(x => x.Id == id);
            if (r == null)
            {
                throw new Exception($"Không thể tìm thấy Region theo ID");
            }

            r.Code = region.Code;
            r.Name = region.Name;
            r.RegionImageUrl = region.RegionImageUrl;

            await _dbContext.SaveChangesAsync();
            return r;
        }
        catch (Exception e)
        {
            throw new Exception(message: $"ERROR: {e.Message}");
        }
    }

    public async Task<Region?> DeleteAsync(Guid id)
    {
        try
        {
            var region = await _dbContext.Regions.FirstOrDefaultAsync();
            if (region == null)
            {
                throw new Exception($"Không tìm thấy region theo ID để xoá");
            }
            _dbContext.Regions.Remove(region);
            await _dbContext.SaveChangesAsync();
            return region;
        }
        catch (Exception e)
        {
            throw new Exception(message: $"ERROR: {e.Message}");
        }
    }
}