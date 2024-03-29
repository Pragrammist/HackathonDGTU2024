using HackathonDHTU.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

public class BaseAppContext<IDerivedClass> : IdentityDbContext<User, IdentityRole<int>, int> 
    where IDerivedClass : BaseAppContext<IDerivedClass>
{
    protected BaseAppContext(DbContextOptions<IDerivedClass> optionsBuilder) : base(optionsBuilder)
    {
        
    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<HistoryAction>().UseTptMappingStrategy();
        modelBuilder.Entity<Entity>().UseTpcMappingStrategy();
        
        modelBuilder.AddHistoryForThisEntity<User>();
        
        modelBuilder.Entity<User>().HasMany(u => u.UserActions).WithOne(a => a.User);
    }

    public override EntityEntry Add(object entity) 
        => Add(entity, base.Add(entity));
    

    public override EntityEntry<TEntity> Add<TEntity>(TEntity entity) 
        => Add(entity, base.Add(entity));


    public override ValueTask<EntityEntry> AddAsync(object entity, CancellationToken cancellationToken = default) 
        => Add(entity, base.AddAsync(entity, cancellationToken));


    public override ValueTask<EntityEntry<TEntity>> AddAsync<TEntity>(TEntity entity, CancellationToken cancellationToken = default) 
        => Add(entity, base.AddAsync(entity, cancellationToken));

    
    
    public override void AddRange(params object[] entities) 
        => AddRange(entities, base.AddRange);

    
    public override void AddRange(IEnumerable<object> entities) => AddRange(entities, base.AddRange);


    public override Task AddRangeAsync(IEnumerable<object> entities, CancellationToken cancellationToken = default)
    => AddRangeAsync(entities, base.AddRangeAsync(entities, cancellationToken));
    




    TResult Add<TResult>(object entity, TResult result)
    {
        if (entity is IEntity derivedEntity)
            derivedEntity.AppendAddAction();

        return result;
    }

    void AddRange<TInput>(TInput entities, Action<TInput> AddRangeFunc) where TInput : IEnumerable<object>
    {
        foreach (var entity in entities)
            Add(entity);

        AddRangeFunc(entities);
    }

    void AddRangeAsync<TInput>(TInput entities, Func<TInput, Task> AddRangeFunc) where TInput : IEnumerable<object>
    {
        foreach (var entity in entities)
            Add(entity);

        AddRangeFunc(entities);
    }

    

}