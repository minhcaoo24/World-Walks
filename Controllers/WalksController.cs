using Microsoft.AspNetCore.Mvc;
using WorldWalks.Models.Domain;
using WorldWalks.Models.DTO.WalkDtos;
using WorldWalks.Models.DTO.RegionDtos;
using WorldWalks.Models.DTO.DifficultyDtos;
using WorldWalks.Repositories.WalkRepository;
using WorldWalks.CustomActionFilters;

namespace WorldWalks.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class WalksController : ControllerBase
{
    private readonly IWalkRepository _walkRepository;
    public WalksController(IWalkRepository walkRepository)
    {
        this._walkRepository = walkRepository;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        try
        {
            var walksDomain = await _walkRepository.GetAllAsync();
            var walksDto = new List<WalkDto>();
            foreach (var domain in walksDomain)
            {
                walksDto.Add(new WalkDto()
                {
                    Id = domain.Id,
                    HikerName = domain.HikerName,
                    Name = domain.Name,
#pragma warning disable CS8601
                    Description = domain.Description,
#pragma warning restore CS8601
                    LengthInKm = domain.LengthInKm,

                    Region = new RegionDto()
                    {
                        Id = domain.Region.Id,
                        Code = domain.Region.Code,
                        Name = domain.Region.Name,
                        RegionImageUrl = domain.Region.RegionImageUrl
                    },

                    Difficulty = new DifficultyDto()
                    {
                        Id = domain.Difficulty.Id,
                        Status = domain.Difficulty.Status
                    }
                });
            }
            return Ok(new
            {
                status = "Thành công",
                data = walksDto
            });
        }
        catch (Exception e)
        {
            return StatusCode(500, new
            {
                status = "Không thành công",
                ERROR = e.Message
            });
        }
    }

    [HttpGet]
    [Route("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        try
        {
            var domain = await _walkRepository.GetByIdAsync(id);
            var walkDto = new WalkDto()
            {
#pragma warning disable CS8602
                Id = domain.Id,
#pragma warning restore CS8602
                HikerName = domain.HikerName,
                Name = domain.Name,
#pragma warning disable CS8601
                Description = domain.Description,
#pragma warning restore CS8601
                LengthInKm = domain.LengthInKm,

                Region = new RegionDto()
                {
                    Id = domain.Region.Id,
                    Code = domain.Region.Code,
                    Name = domain.Region.Name,
                    RegionImageUrl = domain.Region.RegionImageUrl
                },

                Difficulty = new DifficultyDto()
                {
                    Id = domain.Difficulty.Id,
                    Status = domain.Difficulty.Status
                }
            };

            return Ok(new
            {
                status = "Thành công",
                data = walkDto
            });
        }
        catch (Exception e)
        {
            return StatusCode(500, new
            {
                status = "Không thành công",
                ERROR = e.Message
            });
        }
    }

    [HttpPost]
    [ValidateModel]
    public async Task<IActionResult> Create([FromBody] AddWalkRequestDto request)
    {
        try
        {
            var walkDomain = new Walk()
            {
                HikerName = request.HikerName,
                Name = request.Name,
                Description = request.Description,
                LengthInKm = request.LengthInKm,
                DifficultyId = request.DifficultyId,
                RegionId = request.RegionId
            };

            walkDomain = await _walkRepository.CreateAsync(walkDomain);

            var walkDto = new WalkDto()
            {
                Id = walkDomain.Id,
                HikerName = walkDomain.HikerName,
                Name = walkDomain.Name,
#pragma warning disable CS8601
                Description = walkDomain.Description,
#pragma warning restore CS8601
                LengthInKm = walkDomain.LengthInKm,
                Region = new RegionDto()
                {
                    Id = walkDomain.Region.Id,
                    Code = walkDomain.Region.Code,
                    Name = walkDomain.Region.Name,
                    RegionImageUrl = walkDomain.Region.RegionImageUrl
                },
                Difficulty = new DifficultyDto()
                {
                    Id = walkDomain.Difficulty.Id,
                    Status = walkDomain.Difficulty.Status
                }
            };

            return CreatedAtAction(nameof(GetById), new { Id = walkDto.Id }, walkDto);
        }
        catch (Exception e)
        {
            return StatusCode(500, new
            {
                status = "Không thành công",
                ERROR = e.Message
            });
        }
    }

    [HttpPut]
    [Route("{id}")]
    [ValidateModel]
    public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateWalkRequestDto request)
    {
        try
        {
            var walkDomain = new Walk()
            {
                HikerName = request.HikerName,
                Name = request.Name,
                Description = request.Description,
                LengthInKm = request.LengthInKm,
                DifficultyId = request.DifficultyId,
                RegionId = request.RegionId
            };

            walkDomain = await _walkRepository.UpdateAsync(id, walkDomain);

            var walkDto = new WalkDto()
            {
#pragma warning disable CS8602
                Id = walkDomain.Id,
#pragma warning restore CS8602
                HikerName = walkDomain.HikerName,
                Name = walkDomain.Name,
#pragma warning disable CS8601
                Description = walkDomain.Description,
#pragma warning restore CS8601
                LengthInKm = walkDomain.LengthInKm,
                Region = new RegionDto()
                {
                    Id = walkDomain.Region.Id,
                    Code = walkDomain.Region.Code,
                    Name = walkDomain.Region.Name,
                    RegionImageUrl = walkDomain.Region.RegionImageUrl
                },
                Difficulty = new DifficultyDto()
                {
                    Id = walkDomain.Difficulty.Id,
                    Status = walkDomain.Difficulty.Status
                }
            };

            return Ok(new
            {
                status = "Thành công",
                data = walkDto
            });
        }
        catch (Exception e)
        {
            return StatusCode(500, new
            {
                status = "Không thành công",
                ERROR = e.Message
            });
        }
    }

    [HttpDelete]
    [Route("{id}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        try
        {
            var walkDomain = await _walkRepository.DeleteAsync(id);

            var walkDto = new WalkDto()
            {
#pragma warning disable CS8602
                Id = walkDomain.Id,
#pragma warning restore CS8602
                HikerName = walkDomain.HikerName,
                Name = walkDomain.Name,
#pragma warning disable CS8601
                Description = walkDomain.Description,
#pragma warning restore CS8601
                LengthInKm = walkDomain.LengthInKm,
                Region = new RegionDto()
                {
                    Id = walkDomain.Region.Id,
                    Code = walkDomain.Region.Code,
                    Name = walkDomain.Region.Name,
                    RegionImageUrl = walkDomain.Region.RegionImageUrl
                },
                Difficulty = new DifficultyDto()
                {
                    Id = walkDomain.Difficulty.Id,
                    Status = walkDomain.Difficulty.Status
                }
            };

            return Ok(new
            {
                status = "Thành công",
                data = walkDto
            });
        }
        catch (Exception e)
        {
            return StatusCode(500, new
            {
                status = "Không thành công",
                ERROR = e.Message
            });
        }
    }
}