namespace Shell.Models;

public class DirectoryDto
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Path { get; set; } = null!;
    public string NewPath { get; set; } = null!;
    public DateTime CreationDate { get; set; }
    public DateTime EditDate { get; set; }
    public int? ParentDirectoryId { get; set; }
    public int DriveId { get; set; }
}