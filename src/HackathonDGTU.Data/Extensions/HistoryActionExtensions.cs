

using HackathonDHTU.Data.Models;
using Microsoft.EntityFrameworkCore;

public  static class HistoryActionExtensions
{
    public static ModelBuilder AddHistoryForThisEntity<TEntity> (this ModelBuilder modelBuilder) where TEntity : IEntity
    {
        modelBuilder.Entity<IEntity>().HasMany(c => c.ActionsWithEntites).WithMany();
        return modelBuilder;
    }

    public static TEntity AppendAddAction<TEntity>(this TEntity entity) where TEntity: IEntity
    {
        entity.ActionsWithEntites.Add(new HistoryAddAction());
        return entity;
    }

}