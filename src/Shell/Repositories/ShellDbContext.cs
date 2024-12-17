using Microsoft.EntityFrameworkCore;
using Shell.Entities;
using Directory = Shell.Entities.Directory;
using File = Shell.Entities.File;

namespace Shell.Repositories;

public class ShellDbContext : DbContext
{
    public ShellDbContext(DbContextOptions<ShellDbContext> options) : base(options) { }
    
    public DbSet<File> Files { get; set; }
    public DbSet<Directory> Directories { get; set; }
    public DbSet<Drive> Drives { get; set; }
}