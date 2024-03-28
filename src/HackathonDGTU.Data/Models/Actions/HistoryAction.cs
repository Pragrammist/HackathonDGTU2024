namespace HackathonDHTU.Data.Models;

public class HistoryAction : Entity
{
    public int Id { get; set; }

    public virtual string ActionType  => GetType().Name;

    public virtual DateTime Date { get; set; } =  DateTime.UtcNow;

    public User User { get; set; } = null!;

    public virtual string? Reason { get; set; }

    public virtual bool IsReasonable => Reason is not null;

    public virtual string? OldValue  { get; set; }

    public virtual bool HasOldValue => OldValue is not null;

    public override DateTime CreationDate { get => Date; set => Date = value; }

    public string WithEntityAction { get; set; } = nameof(Entity);
}

