using AutoMapper;
using QuickShare.Data.Entities;
using QuickShare.Models;
using QuickShare.Models.Dtos;

namespace QuickShare.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<SpaceEntity, SpaceDto>().ForMember(
            dest => dest.Entries, opt => opt.MapFrom(src => src.Entries)
        );
        CreateMap<EntryEntity, EntryDto>().ForMember(
            dest => dest.Type, 
            opt =>
        {
            opt.MapFrom(src => src.Type == EntryType.Text ? "text" : "other");
        });
        CreateMap<FileEntity, FileDto>();
    }
}