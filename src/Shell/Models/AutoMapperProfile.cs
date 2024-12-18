using AutoMapper;
using Shell.Entities;
using Directory = Shell.Entities.Directory;
using File = Shell.Entities.File;

namespace Shell.Models;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<File, FileDto>().ReverseMap();
        CreateMap<Directory, DirectoryDto>().ReverseMap();
        CreateMap<Drive, DriveDto>().ReverseMap();
    }
}