using Microsoft.EntityFrameworkCore;
using WorldWalks.Data;
using WorldWalks.Models.Domain;

namespace WorldWalks.Repositories.WalkRepository;

public class SqlWalkRepository : IWalkRepository
{
    private readonly WorldWalksDbContext _dbContext;
    public SqlWalkRepository(WorldWalksDbContext dbContext)
    {
        this._dbContext = dbContext;
    }

    public async Task<List<Walk>> GetAllAsync()
    {
        try
        {
            var walks = await _dbContext.Walks.Include(x => x.Region).Include(x => x.Difficulty).ToListAsync();
            if (walks == null)
            {
                throw new Exception($"Không có dữ liệu trong database - TABLE Walk");
            }
            return walks;
        }
        catch (Exception e)
        {
            throw new Exception(message: $"ERROR: {e.Message}");
        }
    }

    public async Task<Walk?> GetByIdAsync(Guid id)
    {
        try
        {
            var walk = await _dbContext.Walks.Include(x => x.Region).Include(x => x.Difficulty).FirstOrDefaultAsync(x => x.Id == id);
            if (walk == null)
            {
                throw new Exception($"Không tìm thấy walk");
            }
            return walk;
        }
        catch (Exception e)
        {
            throw new Exception(message: $"ERROR: {e.Message}");
        }
    }

    public async Task<Walk> CreateAsync(Walk walk)
    {
        try
        {
            await _dbContext.Walks.AddAsync(walk);
            await _dbContext.SaveChangesAsync();

            return await _dbContext.Walks
                        .Include(x => x.Region)
                        .Include(x => x.Difficulty)
                        .FirstAsync(x => x.Id == walk.Id);
        }
        catch (Exception e)
        {
            throw new Exception(message: $"ERROR: {e.Message}");
        }
    }

    public async Task<Walk?> UpdateAsync(Guid id, Walk walk)
    {
        try
        {
            var existedWalk = await _dbContext.Walks.FirstOrDefaultAsync(x => x.Id == id);
            if (existedWalk == null)
            {
                throw new Exception($"Không tìm thấy walk");
            }

            //Mapping
            existedWalk.HikerName = walk.HikerName;
            existedWalk.Name = walk.Name;
            existedWalk.Description = walk.Description;
            existedWalk.LengthInKm = walk.LengthInKm;
            existedWalk.DifficultyId = walk.DifficultyId;
            existedWalk.RegionId = walk.RegionId;

            await _dbContext.SaveChangesAsync();
            return await _dbContext.Walks.Include(x => x.Region).Include(x => x.Difficulty).FirstAsync(x => x.Id == existedWalk.Id);
        }
        catch (Exception e)
        {
            throw new Exception(message: $"ERROR: {e.Message}");
        }
    }

    public async Task<Walk?> DeleteAsync(Guid id)
    {
        try
        {
            var walk = await _dbContext.Walks.Include(x => x.Region).Include(x => x.Difficulty).FirstOrDefaultAsync(x => x.Id == id);
            if (walk == null)
            {
                throw new Exception($"Không tìm thấy walk");
            }
            _dbContext.Walks.Remove(walk);
            await _dbContext.SaveChangesAsync();
            return walk;
        }
        catch (Exception e)
        {
            throw new Exception(message: $"ERROR: {e.Message}");
        }
    }
}