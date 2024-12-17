using Microsoft.EntityFrameworkCore;
using File = Shell.Entities.File;

namespace Shell.Repositories;

public class FileRepository(ShellDbContext context) : IFileRepository
{
    public async Task<IEnumerable<File>> GetAll()
    {
        return await context.Files.AsNoTracking().ToListAsync();
    }

    public async Task<File?> GetById(int id)
    {
        return await context.Files.AsNoTracking().FirstOrDefaultAsync(f => f.Id == id);
    }

    public async Task Add(File file)
    {
        context.Files.Add(file);
        await context.SaveChangesAsync();
    }

    public async Task Update(File file)
    {
        context.Files.Update(file);
        await context.SaveChangesAsync();
    }

    public async Task Delete(File file)
    {
        context.Files.Remove(file);
        await context.SaveChangesAsync();
    }
}