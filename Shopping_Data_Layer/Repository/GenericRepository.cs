using Microsoft.EntityFrameworkCore;
using Shopping_Data_Layer.Common;
using Shopping_Data_Layer.Context;

namespace Shopping_Data_Layer.Repository;

public class GenericRepository<TEntity>(ShoppingContext context):IGenericRepository<TEntity> where TEntity:BaseEntity 
{
    public void Dispose()
    {
        context?.Dispose(); 
    }

    public IQueryable<TEntity> GetEntitiesQuery()
    {
        return context.Set<TEntity>();
    }

    public async Task<TEntity> GetEntityById(long id)
    {
        var entity=await context.Set<TEntity>().FirstOrDefaultAsync(x=>x.Id==id);
        return entity;
    }

    public async Task AddEntity(TEntity entity,bool setFromCreateDate=false)
    {
        entity.CreateDate = setFromCreateDate ? entity.CreateDate:DateTime.Now;
        entity.LastUpdateDate = entity.CreateDate;
        await context.AddAsync(entity);
    }

    public void UpdateEntity(TEntity entity)
    {
        entity.LastUpdateDate = DateTime.Now;
        context.Update(entity);
    }

    public void DeleteEntity(TEntity entity)
    {
        entity.IsDelete=true;
        UpdateEntity(entity);
    }

    public async Task DeleteEntity(long entityId)
    {
        var entity = await GetEntityById(entityId);
        DeleteEntity(entity);
    }

    public async Task<bool> SaveChangesAsync()
    {
       return await context.SaveChangesAsync() > 0;
    }
}