using Microsoft.AspNetCore.Mvc;
using WorldWalks.Models.DTO.DifficultyDtos;
using WorldWalks.Repositories.DifficultyRepository;

namespace WorldWalks.Controllers;

[ApiController]
[Route("/api/v1/[controller]")]
public class DifficultiesController : ControllerBase
{
    private readonly IDifficultyRepository _difficultyRepository;
    public DifficultiesController(IDifficultyRepository difficultyRepository)
    {
        this._difficultyRepository = difficultyRepository;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        try
        {
            var diffsDomain = await _difficultyRepository.GetAllAsync();
            var diffsDto = new List<DifficultyDto>();
            foreach (var diff in diffsDomain)
            {
                diffsDto.Add(new DifficultyDto()
                {
                    Id = diff.Id,
                    Status = diff.Status
                });
            }

            return Ok(new
            {
                status = "Thành công",
                data = diffsDto
            });
        }
        catch (Exception e)
        {
            return StatusCode(500, $"ERROR: {e.Message}");
        }
    }

    [HttpGet]
    [Route("{status}")]
    public async Task<IActionResult> GetByStatus([FromRoute] string status)
    {
        try
        {
            var diff = await _difficultyRepository.GetByStatusAsync(status);
            var diffDto = new DifficultyDto()
            {
#pragma warning disable CS8602
                Id = diff.Id,
#pragma warning restore CS8602
                Status = diff.Status
            };

            return Ok(new
            {
                status = "Thành công",
                data = diffDto
            });
        }
        catch (Exception e)
        {
            return StatusCode(500, $"ERROR: {e.Message}");
        }
    }
}