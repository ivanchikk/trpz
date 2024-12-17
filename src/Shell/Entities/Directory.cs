using System.ComponentModel.DataAnnotations.Schema;
using AutoMapper;
using Shell.Prototype;
using Shell.Services;
using Shell.State;

namespace Shell.Entities;

public class Directory : IPrototype<Directory>
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Path { get; set; } = null!;
    public DateTime CreationDate { get; set; }
    public DateTime EditDate { get; set; }
    public int? ParentDirectoryId { get; set; }
    public int DriveId { get; set; }

    public string State { get; set; } = IDirectoryState.NoFiles;
    [NotMapped] public IDirectoryState DirectoryState { get; set; } = null!;

    public async Task Handle(IDirectoryService directoryService, IMapper mapper)
    {
        DirectoryState = State == IDirectoryState.NoFiles
            ? new NoFilesState(this)
            : new HasFilesState(this);
        await DirectoryState.Handle(directoryService, mapper);
    }

    public Directory? ParentDirectory { get; set; }
    public Drive Drive { get; set; } = null!;
    public ICollection<Directory> ChildDirectories { get; set; } = new List<Directory>();
    public ICollection<File> Files { get; set; } = new List<File>();

    public Directory Clone()
    {
        var directory = (Directory)MemberwiseClone();

        foreach (var childDirectory in ChildDirectories)
            directory.ChildDirectories.Add(childDirectory.Clone());

        foreach (var file in Files)
            directory.Files.Add(file.Clone());

        return directory;
    }
}