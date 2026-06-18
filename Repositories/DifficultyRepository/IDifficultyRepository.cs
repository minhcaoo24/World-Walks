using WorldWalks.Models.Domain;

namespace WorldWalks.Repositories.DifficultyRepository;
public interface IDifficultyRepository
{
    Task<List<Difficulty>> GetAllAsync();
    Task<Difficulty?> GetByStatusAsync(string status);
}