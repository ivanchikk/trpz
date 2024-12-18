using Shell.Models;

namespace Shell.FabricMethod;

public class CreateFileOperationFactory : FileOperationFactory<FileDto>
{
    public override IFileOperation<FileDto> CreateOperation()
    {
        return new CreateFileOperation();
    }
}