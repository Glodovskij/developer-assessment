using DataExporter.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataExporter.Infrastructure.Configurations
{
    public class PolicyConfiguration : IEntityTypeConfiguration<Policy>
    {
        public void Configure(EntityTypeBuilder<Policy> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasMany(policy => policy.Notes)
                .WithOne(note => note.Policy)
                .HasForeignKey(note => note.PolicyId);
        }
    }
}
