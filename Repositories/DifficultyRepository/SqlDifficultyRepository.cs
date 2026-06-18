using Microsoft.EntityFrameworkCore;
using WorldWalks.Data;
using WorldWalks.Models.Domain;

namespace WorldWalks.Repositories.DifficultyRepository;

public class SqlDifficultyRepository : IDifficultyRepository
{
    private readonly WorldWalksDbContext _dbContext;
    public SqlDifficultyRepository(WorldWalksDbContext dbContext)
    {
        this._dbContext = dbContext;
    }

    public async Task<List<Difficulty>> GetAllAsync()
    {
        try
        {
            var diffs = await _dbContext.Difficulties.ToListAsync();
            if (diffs == null)
            {
                throw new Exception($"Không có dữ liệu trong database - TABLE Difficulty");
            }
            return diffs;
        }
        catch (Exception e)
        {
            throw new Exception(message: $"{e.Message}");
        }
    }

    public async Task<Difficulty?> GetByStatusAsync(string status)
    {
        try
        {
            var diff = await _dbContext.Difficulties.FirstOrDefaultAsync(x => x.Status.ToLower() == status.ToLower());
            if(diff == null)
            {
                throw new Exception("Không tìm thấy Difficulty");
            }
            return diff;
        }
        catch (Exception e)
        {
            throw new Exception($"{e.Message}");
        }
    }
}