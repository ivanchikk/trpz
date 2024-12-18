using AutoMapper;
using Shell.Repositories;
using File = Shell.Entities.File;

namespace Shell.FactoryMethod;

public class DeleteFileOperation : IFileOperation<int>
{
    public async Task Execute(IFileRepository repository, IMapper mapper, int id)
    {
        var dto = await repository.GetById(id);
        if (dto == null) return;
        await repository.Delete(mapper.Map<File>(dto));
    }
}