using Microsoft.EntityFrameworkCore;
using Shell.Entities;

namespace Shell.Repositories;

public class DriveRepository(ShellDbContext context) : IDriveRepository
{
    public async Task<IEnumerable<Drive>> GetAll()
    {
        return await context.Drives.AsNoTracking().ToListAsync();
    }

    public async Task<Drive?> GetById(int id)
    {
        return await context.Drives.AsNoTracking().FirstOrDefaultAsync(d => d.Id == id);
    }

    public async Task Add(Drive drive)
    {
        context.Drives.Add(drive);
        await context.SaveChangesAsync();
    }

    public async Task Update(Drive drive)
    {
        context.Drives.Update(drive);
        await context.SaveChangesAsync();
    }

    public async Task Delete(Drive drive)
    {
        context.Drives.Remove(drive);
        await context.SaveChangesAsync();
    }
}