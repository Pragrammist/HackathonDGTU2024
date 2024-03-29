using HackathonDHTU.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace HackathonDGTU.Data.Contexts;

public class HistoryActionsContext : BaseAppContext<HistoryActionsContext>
{

    public DbSet<THistory> HisroryRepository<THistory>() where THistory: HistoryAction
    {
        return Set<THistory>();
    }

    public DbSet<HistoryAction> HisroryRepository()
    {
        return Set<HistoryAction>();
    }

    public HistoryActionsContext(DbContextOptions<HistoryActionsContext> options) : base(options)
    {

    }
}