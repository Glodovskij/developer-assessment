using AutoMapper;
using DataExporter.Application.Dtos;
using DataExporter.Domain.Entities;

namespace DataExporter.Application.AutoMapper
{
    public class AutoMapperProfilesConfig : Profile
    {
        public AutoMapperProfilesConfig()
        {
            CreateMap<CreatePolicyDto, Policy>();

            CreateMap<Policy, ReadPolicyDto>();

            CreateMap<Note, ReadNoteDto>();

            CreateMap<Policy, ExportDto>()
            .ForMember(dest => dest.Notes, opt => opt.MapFrom(src => src.Notes.Select(n => n.Text).ToList()));
        }
    }
}
