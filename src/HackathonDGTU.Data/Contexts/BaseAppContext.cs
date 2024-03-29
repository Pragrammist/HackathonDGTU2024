using HackathonDHTU.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace HackathonDGTU.Data.Contexts;

public class BaseAppContext<IDerivedClass> : IdentityDbContext<User, Role, int> 
    where IDerivedClass : BaseAppContext<IDerivedClass>
{
    protected BaseAppContext(DbContextOptions<IDerivedClass> optionsBuilder) : base(optionsBuilder)
    {
        
    }

    public override DbSet<User> Users { get => (DbSet<User>)base.Users.Where(u => !u.IsDeleted); set => base.Users = value; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        var assembly = GetType().Assembly;
        modelBuilder.ApplyConfigurationsFromAssembly(assembly);
    }

    

    

}