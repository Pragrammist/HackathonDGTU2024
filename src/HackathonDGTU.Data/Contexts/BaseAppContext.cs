using HackathonDHTU.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

public class BaseAppContext : IdentityDbContext
{
    protected DbSet<HistoryAction> HistoryActions { get; set; }

    protected DbSet<HistoryAddAction> HistoryAddActions { get; set; }

    protected DbSet<HistoryDeleteAction> HistoryDeleteActions { get; set; }

    protected DbSet<HistoryRestoreAction> HistoryRestoreActions { get; set; }

    protected DbSet<HistoryUpdateAction> HistoryUpdateActions { get; set; } 

    



    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<HistoryAction>().UseTptMappingStrategy();
        modelBuilder.Entity<Entity>().UseTphMappingStrategy();
    }
}