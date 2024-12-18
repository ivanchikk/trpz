using AutoMapper;
using Shell.Services;

namespace Shell.State;

public interface IDirectoryState
{
    const string HasFiles = "hasFiles";
    const string NoFiles = "noFiles";
    Task Handle(IDirectoryService service, IMapper mapper);
}