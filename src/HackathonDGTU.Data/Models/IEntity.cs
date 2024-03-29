

using HackathonDHTU.Data.Models;

public interface IEntity
{
    public bool IsDeleted { get; set; }

    public DateTime CreationDate { get; set; }

    public DateTime? DeleteDateTime { get; set; }

    public DateTime? RestoreDateTime { get; set; }

    public DateTime? UpdateDateTime { get; set; }

    public List<HistoryAction> ActionsWithEntity { get; set; }
}


public abstract class Entity : IEntity
{
    public virtual bool IsDeleted { get; set; }

    public virtual DateTime? DeleteDateTime { get; set; }

    public virtual DateTime? UpdateDateTime { get; set; }

    public virtual DateTime CreationDate { get; set; } = DateTime.UtcNow;

    public virtual List<HistoryAction> ActionsWithEntity { get; set; } = new List<HistoryAction>();

    public DateTime? RestoreDateTime { get; set; }
}