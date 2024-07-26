using DataExporter.Application.Dtos;

namespace DataExporter.Application.Interfaces
{
    public interface IPolicyService
    {
        Task<ReadPolicyDto> CreatePolicyAsync(CreatePolicyDto createPolicyDto);
        Task<IList<ReadPolicyDto>> ReadPoliciesAsync();
        Task<ReadPolicyDto> ReadPolicyAsync(int id);
        Task<IList<ExportDto>> ExportPoliciesWithNotesByDateRangeAsync(DateTime startDate, DateTime endDate);
    }
}
