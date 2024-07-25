using DataExporter.Application.Dtos;

namespace DataExporter.Application.Interfaces
{
    public interface IPolicyService
    {
        Task<CreatePolicyDto> CreatePolicyAsync(CreatePolicyDto createPolicyDto);
        Task<IList<ReadPolicyDto>> ReadPoliciesAsync();
        Task<ReadPolicyDto> ReadPolicyAsync(int id);
    }
}
