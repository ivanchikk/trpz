using AutoMapper;
using Shell.Repositories;

namespace Shell.FabricMethod;

public interface IFileOperation<TInput>
{
    Task Execute(IFileRepository repository, IMapper mapper, TInput input);
}