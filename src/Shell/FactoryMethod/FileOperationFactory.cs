namespace Shell.FabricMethod;

public abstract class FileOperationFactory<TInput>
{
    public abstract IFileOperation<TInput> CreateOperation();
}