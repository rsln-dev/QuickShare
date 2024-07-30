using Microsoft.AspNetCore.Mvc;
using QuickShare.Models.RequestsDto;
using QuickShare.Services.Interfaces;

namespace QuickShare.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EntryController : ControllerBase
{
    private readonly IEntryService _entryService;

    public EntryController(IEntryService entryService)
    {
        _entryService = entryService;
    }

    // POST api/items
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateEntryDto item)
    {
        var _ = await _entryService.CreateEntry(item.spaceId, item.text);
        
        return Ok();
    }

    // PUT api/items/{id}
    [HttpPatch("{id}")]
    public async Task<IActionResult> UpdateTextEntry(int id, [FromBody] UpdateTextEntryDto item)
    {
        var result = await _entryService.UpdateTextEntry(item.id, item.text);
        
        if (result == false)
        {
            return NotFound(new { message = "Entry not found." });
        }
        
        return Ok();
    }

    // DELETE api/items/{id}
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _entryService.DeleteEntry(id);
        
        if (result == false)
        {
            return NotFound(new { message = "Entry not found." });
        }

        return Ok();    
    }
}