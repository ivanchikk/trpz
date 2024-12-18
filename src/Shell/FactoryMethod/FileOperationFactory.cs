namespace Shell.FactoryMethod;

public abstract class FileOperationFactory<TInput>
{
    public abstract IFileOperation<TInput> CreateOperation();
}