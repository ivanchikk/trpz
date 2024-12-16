using Microsoft.EntityFrameworkCore;
using Directory = Shell.Entities.Directory;

namespace Shell.Repositories;

public class DirectoryRepository(ShellDbContext context) : IDirectoryRepository
{
    public async Task<IEnumerable<Directory>> GetAll()
    {
        return await context.Directories.AsNoTracking().ToListAsync();
    }

    public async Task<Directory?> GetById(int id)
    {
        return await context.Directories.AsNoTracking().FirstOrDefaultAsync(d => d.Id == id);
    }

    public async Task Add(Directory directory)
    {
        context.Directories.Add(directory);
        await context.SaveChangesAsync();
    }

    public async Task Update(Directory directory)
    {
        context.Directories.Update(directory);
        await context.SaveChangesAsync();
    }

    public async Task Delete(Directory directory)
    {
        context.Directories.Remove(directory);
        await context.SaveChangesAsync();
    }
}