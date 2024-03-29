using HackathonDHTU.Data.Models;
using Microsoft.AspNetCore.Identity;

public class Role : IdentityRole<int>, IEntity
{
    public bool IsDeleted { get; set; }
    
    public DateTime? DeleteDateTime { get; set; }
    
    public DateTime? UpdateDateTime { get; set; }

    public DateTime CreationDate { get; set; }  = DateTime.UtcNow;
    
    public List<HistoryAction> ActionsWithEntity { get; set; } = new List<HistoryAction>();

    public DateTime? RestoreDateTime { get; set; }
}