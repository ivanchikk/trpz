using AutoMapper;
using Shell.FabricMethod;
using Shell.Models;
using Shell.Repositories;
using File = Shell.Entities.File;

namespace Shell.Services;

public class FileService(
    IFileRepository fileRepository,
    IMapper mapper,
    IDirectoryRepository directoryRepository,
    IDirectoryService directoryService) : IFileService
{
    public async Task ExecuteOperation<TInput>(FileOperationFactory<TInput> factory, TInput input)
    {
        var operation = factory.CreateOperation();
        await operation.Execute(fileRepository, mapper, input);
    }

    public async Task<IEnumerable<FileDto>> GetAll()
    {
        return mapper.Map<IEnumerable<FileDto>>(await fileRepository.GetAll());
    }

    public async Task<FileDto?> GetById(int id)
    {
        return mapper.Map<FileDto>(await fileRepository.GetById(id));
    }

    public async Task<IEnumerable<FileDto>> GetByFilters(string? name, DateTime? date)
    {
        var files = await fileRepository.GetAll();
        var result = files
            .Where(f => (name == null || name == f.Name) && (!date.HasValue || date == f.CreationDate));

        return mapper.Map<IEnumerable<FileDto>>(result);
    }

    public async Task Add(FileDto dto)
    {
        await fileRepository.Add(mapper.Map<File>(dto));
        await HandleDirectoryState(dto);
    }

    public async Task Copy(FileDto dto, string path)
    {
        var files = await fileRepository.GetAll();
        if (files.Where(f => f.Path == path).Any(f => f.Name == dto.Name))
            throw new Exception($"File with name {dto.Name} already exists");

        dto.Path = dto.NewPath;
        await fileRepository.Add(mapper.Map<File>(dto));
        await HandleDirectoryState(dto);
    }

    public async Task Update(FileDto dto)
    {
        await fileRepository.Update(mapper.Map<File>(dto));
        await HandleDirectoryState(dto);
    }

    public async Task Delete(int id)
    {
        var dto = await GetById(id);
        if (dto == null) return;

        await fileRepository.Delete(mapper.Map<File>(dto));
        await HandleDirectoryState(dto);
    }

    private async Task HandleDirectoryState(FileDto? dto)
    {
        if (dto?.DirectoryId != null)
            (await directoryRepository.GetById(dto.DirectoryId.Value))?.Handle(directoryService, mapper);
    }
}