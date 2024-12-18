using AutoMapper;
using Shell.Models;
using Shell.Services;
using Directory = Shell.Entities.Directory;

namespace Shell.State;

public class HasFilesState(Directory directory) : IDirectoryState
{
    public async Task Handle(IDirectoryService service, IMapper mapper)
    {
        if (directory.Files.Count == 0)
        {
            directory.State = IDirectoryState.NoFiles;
            directory.DirectoryState = new NoFilesState(directory);
            await service.Update(mapper.Map<DirectoryDto>(directory));
        }
    }
}