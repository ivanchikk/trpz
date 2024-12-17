using Microsoft.AspNetCore.Mvc;
using Shell.Models;
using Shell.Services;

namespace Shell.Controllers;

[Route("api/[controller]")]
[ApiController]
public class FileController(IFileService fileService) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<FileDto>>> GetAllFiles([FromQuery] string? name,
        [FromQuery] DateTime? creationDate)
    {
        IEnumerable<FileDto> files;

        if (name != null || creationDate.HasValue)
            files = await fileService.GetByFilters(name, creationDate);
        else
            files = await fileService.GetAll();

        return Ok(files);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<FileDto>> GetFileById(int id)
    {
        var file = await fileService.GetById(id);

        return file != null ? Ok(file) : NotFound();
    }

    [HttpPost]
    public async Task<ActionResult> CreateFile([FromBody] FileDto dto)
    {
        await fileService.Add(dto);
        return Ok();
    }

    [HttpPost("copy")]
    public async Task<ActionResult> CopyFile([FromBody] FileDto dto)
    {
        try
        {
            await fileService.Copy(dto, dto.NewPath);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }

        return Ok();
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult> UpdateFileById(int id, [FromBody] FileDto dto)
    {
        if (await fileService.GetById(id) == null)
            return NotFound();

        await fileService.Update(dto);

        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult> DeleteFileById(int id)
    {
        await fileService.Delete(id);

        return NoContent();
    }
}