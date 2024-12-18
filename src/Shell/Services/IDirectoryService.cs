using Shell.Models;

namespace Shell.Services;

public interface IDirectoryService
{
    Task<IEnumerable<DirectoryDto>> GetAll();
    Task<IEnumerable<DirectoryDto>> GetContent(string path);
    Task<DirectoryDto?> GetById(int id);
    Task Add(DirectoryDto dto);
    Task Copy(DirectoryDto dto, string path);
    Task Update(DirectoryDto dto);
    Task Delete(int id);
}