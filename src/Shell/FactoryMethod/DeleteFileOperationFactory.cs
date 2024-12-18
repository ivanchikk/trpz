namespace Shell.FactoryMethod;

public class DeleteFileOperationFactory : FileOperationFactory<int>
{
    public override IFileOperation<int> CreateOperation()
    {
        return new DeleteFileOperation();
    }
}