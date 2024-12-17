namespace Shell.Prototype;

public interface IPrototype<T> where T : class
{
    T Clone()
    {
        return (T)MemberwiseClone();
    }
}