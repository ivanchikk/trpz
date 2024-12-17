namespace Shell.Models;

public class FileDto
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Path { get; set; } = null!;
    public string NewPath { get; set; } = null!;
    public DateTime CreationDate { get; set; }
    public DateTime EditDate { get; set; }
    public int? DirectoryId { get; set; }
    public int DriveId { get; set; }
}