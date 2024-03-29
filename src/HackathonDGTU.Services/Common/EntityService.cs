using HackathonDGTU.Data.Contexts;
using HackathonDHTU.Data.Models;
using HackathonDGTU.Services.Services;
using HackathonDGTU.Services.Dtos.User;
using HackathonDGTU.Services.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace HackathonDGTU.Services.Common
{
    public class EntityService<TDbContext> 
        where TDbContext : BaseAppContext<TDbContext>
    {

        readonly TDbContext _dbContext;
        readonly IAuthService _authService;

        UserDto CurrentUser { get; }

        public EntityService(TDbContext dbContext, IAuthService authService)
        {
            _dbContext = dbContext;
            _authService = authService;
            CurrentUser = _authService.CurrentUser;
        }

        public virtual async Task Add<TEntity>(TEntity entity, bool callSaveChanges = false, HistoryAddAction? inputActionData = null) where TEntity : IEntity
        {
            var dbUser = await _dbContext.Users.FindAsync(CurrentUser.Id);

            if(dbUser is null)
                throw new NoneAuthorizedException(); 

            var addAction = inputActionData ?? new HistoryAddAction();

            addAction.User = dbUser;

            entity.ActionsWithEntity.Add(addAction);
            
            await _dbContext.AddAsync(entity);

            if(callSaveChanges)
                await _dbContext.SaveChangesAsync();
        }


        public virtual async Task Update<TEntity>(TEntity entity, bool callSaveChanges = false, HistoryUpdateAction? inputActionData = null) where TEntity : IEntity
        {
            var dbUser = await _dbContext.Users.FindAsync(CurrentUser.Id);

            if(dbUser is null)
                throw new NoneAuthorizedException(); 

            var addAction = inputActionData ?? new HistoryUpdateAction();

            addAction.User = dbUser;

            entity.ActionsWithEntity.Add(addAction);

            entity.UpdateDateTime = DateTime.UtcNow;
            
            _dbContext.Entry(entity).State = EntityState.Modified;
            
            _dbContext.Update(entity);

            if(callSaveChanges)
                await _dbContext.SaveChangesAsync();
        }

        public virtual async Task Delete<TEntity>(TEntity entity, bool callSaveChanges = false, HistoryDeleteAction? inputActionData = null) where TEntity : IEntity
        {
            var dbUser = await _dbContext.Users.FindAsync(CurrentUser.Id);

            if(dbUser is null)
                throw new NoneAuthorizedException(); 

            var addAction = inputActionData ?? new HistoryDeleteAction();

            addAction.User = dbUser;

            entity.DeleteDateTime = DateTime.UtcNow;
            
            entity.IsDeleted = true;

            entity.ActionsWithEntity.Add(addAction);
            
            _dbContext.Entry(entity).State = EntityState.Modified;
            
            _dbContext.Update(entity);

            if(callSaveChanges)
                await _dbContext.SaveChangesAsync();
        }

        public virtual async Task Restore<TEntity>(TEntity entity, bool callSaveChanges = false, HistoryDeleteAction? inputActionData = null) where TEntity : IEntity
        {
            var dbUser = await _dbContext.Users.FindAsync(CurrentUser.Id);

            if(dbUser is null)
                throw new NoneAuthorizedException(); 

            var addAction = inputActionData ?? new HistoryDeleteAction();

            addAction.User = dbUser;

            entity.RestoreDateTime = DateTime.UtcNow;
            
            entity.IsDeleted = false;

            entity.ActionsWithEntity.Add(addAction);
            
            _dbContext.Entry(entity).State = EntityState.Modified;
            
            _dbContext.Update(entity);

            if(callSaveChanges)
                await _dbContext.SaveChangesAsync();
        }

    }
}