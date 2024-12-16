using Microsoft.EntityFrameworkCore;
using Shell.Models;
using Shell.Repositories;
using Shell.Services;

namespace Shell;

public class ShellApplication
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

        builder.Services
            .AddDbContext<ShellDbContext>(opt => opt.UseNpgsql(connectionString))
            .AddAutoMapper(typeof(AutoMapperProfile))
            .AddScoped<IFileRepository, FileRepository>()
            .AddScoped<IDirectoryRepository, DirectoryRepository>()
            .AddScoped<IDriveRepository, DriveRepository>()
            .AddScoped<IFileService, FileService>()
            .AddScoped<IDirectoryService, DirectoryService>()
            .AddScoped<IDriveService, DriveService>()
            .AddControllers();

        var app = builder.Build();

        using (var scope = app.Services.CreateScope())
        {
            var context = scope.ServiceProvider.GetRequiredService<ShellDbContext>();
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
        }

        app.UseRouting();
        app.UseHttpsRedirection();
        app.MapControllers();
        app.MapGet("/", () => "Hello World!");

        app.Run();
    }
}