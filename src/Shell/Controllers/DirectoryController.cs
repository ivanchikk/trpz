using Microsoft.AspNetCore.Mvc;
using Shell.Models;
using Shell.Services;

namespace Shell.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DirectoryController(IDirectoryService directoryService) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<DirectoryDto>>> GetAllDirectories()
    {
        var directories = await directoryService.GetAll();

        return Ok(directories);
    }

    [HttpGet("get-content")]
    public async Task<ActionResult<IEnumerable<DirectoryDto>>> GetDirectoryContent([FromQuery] string path)
    {
        var directories = await directoryService.GetContent(path);

        return Ok(directories);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<DirectoryDto>> GetDirectoryById(int id)
    {
        var directory = await directoryService.GetById(id);

        return directory != null ? Ok(directory) : NotFound();
    }

    [HttpPost]
    public async Task<ActionResult> Post([FromBody] DirectoryDto dto)
    {
        await directoryService.Add(dto);
        return Ok();
    }

    [HttpPost("copy")]
    public async Task<ActionResult> CopyDirectory([FromBody] DirectoryDto dto)
    {
        try
        {
            await directoryService.Copy(dto, dto.NewPath);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }

        return Ok();
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult> UpdateDirectoryById(int id, [FromBody] DirectoryDto dto)
    {
        var directory = await directoryService.GetById(id);
        if (directory == null)
            return NotFound();

        await directoryService.Update(directory);

        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult> DeleteDirectoryById(int id)
    {
        await directoryService.Delete(id);

        return NoContent();
    }
}