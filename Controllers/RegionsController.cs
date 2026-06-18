using Microsoft.AspNetCore.Mvc;
using WorldWalks.Models.Domain;
using WorldWalks.Repositories.RegionRepository;
using WorldWalks.Models.DTO.RegionDtos;
using WorldWalks.CustomActionFilters;

namespace WorldWalks.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class RegionsController : ControllerBase
{
    private readonly IRegionRepository _regionRepository;
    public RegionsController(IRegionRepository regionRepository)
    {
        this._regionRepository = regionRepository;
    }

    [HttpGet]
    //SELECT * FROM "Regions";
    public async Task<IActionResult> GetAll()
    {
        try
        {
            var regionsDomain = await _regionRepository.GetAllAsync();
            var regionsDto = new List<RegionDto>();
            foreach (var domain in regionsDomain)
            {
                regionsDto.Add(new RegionDto()
                {
                    Id = domain.Id,
                    Code = domain.Code,
                    Name = domain.Name,
                    RegionImageUrl = domain.RegionImageUrl
                });
            }

            return Ok(new
            {
                status = "Thành công",
                data = regionsDto
            });
        }
        catch (Exception e)
        {
            return StatusCode(500, $"ERROR: {e.Message}");
        }
    }

    [HttpGet]
    [Route("{id}")]
    [ValidateModel]
    //SELECT * FROM "Regions" WHERE "Id"='id';
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        try
        {
            // var regionDomain = await _dbContext.Regions.FirstOrDefaultAsync(x => x.Id == id);
            var regionDomain = await _regionRepository.GetByIdAsync(id);

            var regionDto = new RegionDto()
            {
#pragma warning disable CS8602
                Id = regionDomain.Id,
#pragma warning restore CS8602
                Code = regionDomain.Code,
                Name = regionDomain.Name,
                RegionImageUrl = regionDomain.RegionImageUrl
            };

            return Ok(new
            {
                status = "Thành công",
                data = regionDto
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
    //INSERT INTO "Regions" ("Id", "Code", "Name", "RegionImageUrl") VALUES ('.....', '.....', '.....', '.....');
    public async Task<IActionResult> Create([FromBody] AddRegionRequestDto request)
    {
        try
        {
            var regionDomain = new Region()
            {
                Code = request.Code,
                Name = request.Name,
                RegionImageUrl = request.RegionImageUrl
            };

            regionDomain = await _regionRepository.CreateAsync(regionDomain);

            var regionDto = new RegionDto()
            {
                Id = regionDomain.Id,
                Code = regionDomain.Code,
                Name = regionDomain.Name,
                RegionImageUrl = regionDomain.RegionImageUrl
            };

            return CreatedAtAction(nameof(GetById), new { Id = regionDto.Id }, regionDto);
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
    //UPDATE "Regions" SET "column1"='value1', "column2"='value2',... WHERE condition
    public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateRegionRequestDto request)
    {
        try
        {
            var regionDomain = new Region()
            {
                Code = request.Code,
                Name = request.Name,
                RegionImageUrl = request.RegionImageUrl
            };

            regionDomain = await _regionRepository.UpdateAsync(id, regionDomain);

            var regionDto = new RegionDto()
            {
#pragma warning disable CS8602
                Id = regionDomain.Id,
#pragma warning restore CS8602
                Code = regionDomain.Code,
                Name = regionDomain.Name,
                RegionImageUrl = regionDomain.RegionImageUrl
            };

            return Ok(new
            {
                status = "Cập nhật thông tin thành công.",
                data = regionDto
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
    //DELETE FROM "Regions" WHERE condition
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        try
        {
            var regionDomain = await _regionRepository.DeleteAsync(id);

            var regionDto = new RegionDto()
            {
#pragma warning disable CS8602
                Id = regionDomain.Id,
#pragma warning restore CS8602
                Code = regionDomain.Code,
                Name = regionDomain.Name,
                RegionImageUrl = regionDomain.RegionImageUrl
            };

            return Ok(new
            {
                status = "Xoá thông tin thành công.",
                data = regionDto
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