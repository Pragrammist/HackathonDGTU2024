

public interface IEntity
{
    public bool IsDeleted { get; set; }

    public DateTime CreationDate { get; set; }

    public DateTime? DeleteDateTime { get; set; }

    public DateTime? UpdateDateTime { get; set; }
}


public abstract class Entity : IEntity
{
    public virtual bool IsDeleted { get; set; }

    public virtual DateTime? DeleteDateTime { get; set; }

    public virtual DateTime? UpdateDateTime { get; set; }

    public virtual DateTime CreationDate { get; set; } = DateTime.UtcNow;
}