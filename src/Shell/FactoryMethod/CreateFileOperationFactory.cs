using Shell.Models;

namespace Shell.FactoryMethod;

public class CreateFileOperationFactory : FileOperationFactory<FileDto>
{
    public override IFileOperation<FileDto> CreateOperation()
    {
        return new CreateFileOperation();
    }
}