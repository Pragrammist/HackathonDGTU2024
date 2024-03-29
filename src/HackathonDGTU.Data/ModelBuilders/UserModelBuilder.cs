using HackathonDHTU.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HackathonDGTU.Data.ModelBuilders
{
    public class UserModelBuilder : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasMany(u => u.ActionsWithEntites).WithMany();
            builder.HasMany(u => u.UserActions).WithOne(a => a.User);
        }
    }
}