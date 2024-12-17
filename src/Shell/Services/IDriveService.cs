using Shell.Models;

namespace Shell.Services;

public interface IDriveService
{
    Task<IEnumerable<DriveDto>> GetAll();
    Task<DriveDto?> GetById(int id);
    Task Add(DriveDto dto);
    Task Update(DriveDto dto);
    Task Delete(int id);
}