using DataExporter.Domain.Entities;
using DataExporter.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DataExporter.Infrastructure.Repositories
{
    public class PolicyRepository : IPolicyRepository
    {
        private readonly ExporterDbContext _dbContext;

        public PolicyRepository(ExporterDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Policy> CreatePolicyAsync(Policy createPolicy)
        {
            _dbContext.Policies.Add(createPolicy);
            var result = await _dbContext.SaveChangesAsync();

            if(result == 1)
            {
                return createPolicy;
            }

            return null;
        }

        public async Task<IList<Policy>> ReadPoliciesAsync()
        {
            return await _dbContext.Policies.ToListAsync();
        }

        public async Task<IList<Policy>> ReadPoliciesWithNotesByDateRangeAsync(DateTime startDate, DateTime endDate)
        {
            return await _dbContext.Policies
                .Include(policy => policy.Notes)
                .Where(p => p.StartDate >= startDate && p.StartDate <= endDate)
                .ToListAsync();
        }

        public async Task<Policy> ReadPolicyAsync(int id)
        {
            var policy = await _dbContext.Policies.FirstOrDefaultAsync(x => x.Id == id);

            return policy;
        }
    }
}
