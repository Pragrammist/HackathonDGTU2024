using HackathonDHTU.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HackathonDGTU.Data.ModelBuilders
{
    public class HistoryActionModelBuilder : IEntityTypeConfiguration<HistoryAction>
    {
        public void Configure(EntityTypeBuilder<HistoryAction> builder)
        {
            builder.UseTptMappingStrategy();
        }
    }
}