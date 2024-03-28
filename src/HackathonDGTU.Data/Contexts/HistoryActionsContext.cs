using HackathonDHTU.Data.Models;
using Microsoft.EntityFrameworkCore;

public class HistoryActionsContext : DbContext
{
    protected DbSet<HistoryAction> HistoryActions { get; set; }

    protected DbSet<HistoryAddAction> HistoryAddActions { get; set; }

    protected DbSet<HistoryDeleteAction> HistoryDeleteActions { get; set; }

    protected DbSet<HistoryRestoreAction> HistoryRestoreActions { get; set; }

    protected DbSet<HistoryUpdateAction> HistoryUpdateActions { get; set; } 

    



    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<HistoryAction>().UseTptMappingStrategy();
    }
}