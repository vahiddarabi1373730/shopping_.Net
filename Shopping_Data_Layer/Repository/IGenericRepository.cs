using Shopping_Data_Layer.Common;

namespace Shopping_Data_Layer.Repository;

public interface IGenericRepository<TEntity>:IDisposable where TEntity:BaseEntity
{
    IQueryable<TEntity> GetEntitiesQuery();
    Task<TEntity> GetEntityById(long id);
    Task  AddEntity(TEntity entity,bool setFromCreateDate=false);
    void UpdateEntity(TEntity entity,bool setFromCreateDate=false);
    void DeleteEntity(TEntity entity);
    Task DeleteEntity(long entityId);
    Task<bool> SaveChangesAsync();
    
}