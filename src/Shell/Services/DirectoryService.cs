using AutoMapper;
using Shell.Models;
using Shell.Repositories;
using Directory = Shell.Entities.Directory;

namespace Shell.Services;

public class DirectoryService(IDirectoryRepository directoryRepository, IMapper mapper) : IDirectoryService
{
    public async Task<IEnumerable<DirectoryDto>> GetAll()
    {
        return mapper.Map<IEnumerable<DirectoryDto>>(await directoryRepository.GetAll());
    }

    public async Task<IEnumerable<DirectoryDto>> GetContent(string path)
    {
        var directories = await directoryRepository.GetAll();

        return mapper.Map<IEnumerable<DirectoryDto>>(directories.Where(d => d.Path == path));
    }

    public async Task<DirectoryDto?> GetById(int id)
    {
        return mapper.Map<DirectoryDto>(await directoryRepository.GetById(id));
    }

    public async Task Add(DirectoryDto dto)
    {
        await directoryRepository.Add(mapper.Map<Directory>(dto));
    }

    public async Task Copy(DirectoryDto dto, string path)
    {
        var directories = await directoryRepository.GetAll();
        if (directories.Where(d => d.Path == dto.Path).Any(d => d.Name == dto.Name))
            throw new Exception($"Directory with name {dto.Name} already exists");

        dto.Path = dto.NewPath;
        await directoryRepository.Add(mapper.Map<Directory>(dto));
    }

    public async Task Update(DirectoryDto dto)
    {
        await directoryRepository.Update(mapper.Map<Directory>(dto));
    }

    public async Task Delete(int id)
    {
        var dto = await GetById(id);
        if (dto == null) return;
        
        await directoryRepository.Delete(mapper.Map<Directory>(dto));
    }
}