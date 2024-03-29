using HackathonDHTU.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace HackathonDGTU.Data.Contexts;

public class BaseAppContext<IDerivedClass> : IdentityDbContext<User, IdentityRole<int>, int> 
    where IDerivedClass : BaseAppContext<IDerivedClass>
{
    protected BaseAppContext(DbContextOptions<IDerivedClass> optionsBuilder) : base(optionsBuilder)
    {
        
    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        var assembly = GetType().Assembly;
        modelBuilder.ApplyConfigurationsFromAssembly(assembly);
    }

    

    

}