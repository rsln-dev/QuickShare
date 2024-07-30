using System.Net;
using Microsoft.AspNetCore.Mvc;
using QuickShare.Models.Dtos;
using QuickShare.Models.RequestsDto;
using QuickShare.Services.Interfaces;

namespace QuickShare.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SpaceController : ControllerBase
{
    private readonly ISpaceService _spaceService;

    public SpaceController(ISpaceService spaceService)
    {
        _spaceService = spaceService;
    }

    [HttpGet("{slug}")]
    public async Task<ActionResult<SpaceDto>> Get(string slug)
    {
        var result = await _spaceService.GetSpace(slug);
        
        if (result == null)
        {
            return NotFound(new { message = $"Space with slug '{slug}' not found." });
        }

        return Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult> Create([FromBody] CreateSpaceDto item)
    {
        var slug = await _spaceService.CreateSpace(item.length, item.ttl);
        
        return Ok(slug);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var result = await _spaceService.DeleteSpace(id);
        
        if (result == false)
        {
            return NotFound(new { message = $"Space not found." });
        }

        return Ok();    }
}