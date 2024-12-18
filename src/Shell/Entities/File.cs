using Shell.Prototype;

namespace Shell.Entities;

public class File : IPrototype<File>
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Path { get; set; } = null!;
    public DateTime CreationDate { get; set; }
    public DateTime EditDate { get; set; }
    public int? DirectoryId { get; set; }
    public int DriveId { get; set; }

    public Directory? Directory { get; set; }
    public Drive Drive { get; set; } = null!;

    public File Clone()
    {
        return (File)MemberwiseClone();
    }
}