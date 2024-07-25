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

        public async Task<Policy> CreatePolicyAsync(Policy createPolicyDto)
        {
            return await Task.FromResult(new Policy());
        }

        public async Task<IList<Policy>> ReadPoliciesAsync()
        {
            return await _dbContext.Policies.ToListAsync();
        }

        public async Task<Policy> ReadPolicyAsync(int id)
        {
            var policy = await _dbContext.Policies.FirstOrDefaultAsync(x => x.Id == id);

            return policy;
        }
    }
}
