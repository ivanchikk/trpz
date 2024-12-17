using AutoMapper;
using Shell.Entities;
using Shell.Models;
using Shell.Repositories;

namespace Shell.Services;

public class DriveService(IDriveRepository driveRepository, IMapper mapper) : IDriveService
{
    public async Task<IEnumerable<DriveDto>> GetAll()
    {
        return mapper.Map<IEnumerable<DriveDto>>(await driveRepository.GetAll());
    }

    public async Task<DriveDto?> GetById(int id)
    {
        return mapper.Map<DriveDto>(await driveRepository.GetById(id));
    }

    public async Task Add(DriveDto dto)
    {
        await driveRepository.Add(mapper.Map<Drive>(dto));
    }

    public async Task Update(DriveDto dto)
    {
        await driveRepository.Update(mapper.Map<Drive>(dto));
    }

    public async Task Delete(int id)
    {
        var dto = await GetById(id);
        await driveRepository.Delete(mapper.Map<Drive>(dto));
    }
}