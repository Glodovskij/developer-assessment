using DataExporter.Domain.Entities;

namespace DataExporter.Domain.Repositories
{
    public interface IPolicyRepository
    {
        Task<Policy> CreatePolicyAsync(Policy createPolicyDto);
        Task<IList<Policy>> ReadPoliciesAsync();
        Task<Policy> ReadPolicyAsync(int id);
        Task<IList<Policy>> ReadPoliciesWithNotesByDateRangeAsync(DateTime startDate, DateTime endDate);
    }
}
