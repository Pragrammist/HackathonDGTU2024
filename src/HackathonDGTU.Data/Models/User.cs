using Microsoft.AspNetCore.Identity;

namespace HackathonDHTU.Data.Models;

public class User : IdentityUser<int>, IEntity
{
    public DateTime DateTimeRegistration { get; set; } = DateTime.UtcNow;

    public DateTime? DateTimeLogin { get; set; }

    public DateTime? DateTimeLogout { get; set; }

    public DateTime? DataUpdated { get; set; }

    public bool IsBanned { get; set; }

    public bool IsDeleted { get; set; }
    
    public DateTime? DeleteDateTime { get; set; }
    
    public DateTime? UpdateDateTime { get; set; }

    public DateTime CreationDate { get => DateTimeRegistration; set => DateTimeRegistration = value; }

    public List<HistoryAction> UserActions { get; set; } = new List<HistoryAction>();
    
    public List<HistoryAction> ActionsWithEntites { get; set; } = new List<HistoryAction>();
}

