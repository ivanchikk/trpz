using AutoMapper;
using Shell.Models;
using Shell.Repositories;
using File = Shell.Entities.File;

namespace Shell.FabricMethod;

public class CreateFileOperation : IFileOperation<FileDto>
{
    public async Task Execute(IFileRepository repository, IMapper mapper, FileDto dto)
    {
        await repository.Add(mapper.Map<File>(dto));
    }
}