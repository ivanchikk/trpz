using Shell.FactoryMethod;
using Shell.Models;

namespace Shell.Services;

public interface IFileService
{
    Task ExecuteOperation<TInput>(FileOperationFactory<TInput> factory, TInput input);
    Task<IEnumerable<FileDto>> GetAll();
    Task<FileDto?> GetById(int id);
    Task<IEnumerable<FileDto>> GetByFilters(string? name, DateTime? date);
    Task Add(FileDto dto);
    Task Copy(FileDto dto, string path);
    Task Update(FileDto dto);
    Task Delete(int id);
}