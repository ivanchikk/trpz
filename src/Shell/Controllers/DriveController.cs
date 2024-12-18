using Microsoft.AspNetCore.Mvc;
using Shell.Models;
using Shell.Services;

namespace Shell.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DriveController(IDriveService driveService) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<DriveDto>>> GetAllDrives()
    {
        var drives = await driveService.GetAll();

        return Ok(drives);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<DriveDto>> SwitchDriveById(int id)
    {
        var drive = await driveService.GetById(id);
        
        return drive != null ? Ok(drive) : NotFound();
    }

    [HttpPost]
    public async Task<ActionResult> CreateDrive([FromBody] DriveDto dto)
    {
        await driveService.Add(dto);
        return Ok();
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult> UpdateDriveById(int id, [FromBody] DriveDto dto)
    {
        if (await driveService.GetById(id) == null)
            return NotFound();

        await driveService.Update(dto);
        
        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult> DeleteDriveById(int id)
    {
        await driveService.Delete(id);

        return NoContent();
    }
}