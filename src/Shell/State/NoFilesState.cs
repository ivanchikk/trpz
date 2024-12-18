using AutoMapper;
using Shell.Models;
using Shell.Services;
using Directory = Shell.Entities.Directory;

namespace Shell.State;

public class NoFilesState(Directory directory) : IDirectoryState
{
    public async Task Handle(IDirectoryService service, IMapper mapper)
    {
        if (directory.Files.Count != 0)
        {
            directory.State = IDirectoryState.HasFiles;
            directory.DirectoryState = new HasFilesState(directory);
            await service.Update(mapper.Map<DirectoryDto>(directory));
        }
    }
}