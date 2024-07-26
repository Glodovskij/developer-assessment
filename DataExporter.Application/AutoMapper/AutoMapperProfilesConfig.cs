using AutoMapper;
using DataExporter.Application.Dtos;
using DataExporter.Domain.Entities;

namespace DataExporter.Application.AutoMapper
{
    public class AutoMapperProfilesConfig : Profile
    {
        public AutoMapperProfilesConfig()
        {
            CreateMap<CreatePolicyDto, Policy>().ReverseMap();

            CreateMap<ReadPolicyDto, Policy>().ReverseMap();

            CreateMap<ReadNoteDto, Note>().ReverseMap();
        }
    }
}
