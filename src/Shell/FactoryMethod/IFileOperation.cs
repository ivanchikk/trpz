using AutoMapper;
using Shell.Repositories;

namespace Shell.FactoryMethod;

public interface IFileOperation<TInput>
{
    Task Execute(IFileRepository repository, IMapper mapper, TInput input);
}