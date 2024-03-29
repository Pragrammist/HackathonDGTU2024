using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HackathonDGTU.Data.Contexts;

public  static class HistoryActionExtensions
{
    public static ModelBuilder AddHistoryForThisEntity<TEntity> (this ModelBuilder modelBuilder) where TEntity : IEntity
    {
        modelBuilder.Entity<IEntity>().HasMany(c => c.ActionsWithEntity).WithMany();
        return modelBuilder;
    }

    public static EntityTypeBuilder<TEntity> AddHistoryForThisEntity<TEntity> (this EntityTypeBuilder<TEntity> modelBuilder) where TEntity : Entity
    {
        modelBuilder.HasMany(c => c.ActionsWithEntity).WithMany();
        return modelBuilder;
    }
}