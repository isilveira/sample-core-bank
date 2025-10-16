using Microsoft.EntityFrameworkCore;
using SampleCoreBank.Core.Domain.Interfaces.Infrastructures.Data;

namespace SampleCoreBank.Infrastructures.Data
{
	public class Writer: IWriter
    {
        protected DbContext Context { get; private set; }
        public Writer(DbContext context)
        {
            Context = context;
        }
        public virtual IQueryable<TEntity> Query<TEntity>() where TEntity : class
        {
            return Context.Set<TEntity>().AsQueryable();
        }
        public virtual void Add<TEntity>(TEntity entity) where TEntity : class
		{
            Context.Set<TEntity>().Add(entity);
        }
        public virtual Task AddAsync<TEntity>(TEntity entity) where TEntity : class
		{
            return Context.Set<TEntity>().AddAsync(entity).AsTask();
        }
        public virtual void AddRange<TEntity>(params TEntity[] entities) where TEntity : class
		{
            Context.Set<TEntity>().AddRange(entities);
        }
        public virtual Task AddRangeAsync<TEntity>(params TEntity[] entities) where TEntity : class
		{
            return Context.Set<TEntity>().AddRangeAsync(entities);
        }
        public virtual void Remove<TEntity>(TEntity entity) where TEntity : class
		{
            Context.Set<TEntity>().Remove(entity);
        }
        public virtual void RemoveRange<TEntity>(params TEntity[] entities) where TEntity : class
		{
            Context.Set<TEntity>().RemoveRange(entities);
        }
        public virtual int Commit()
        {
            return Context.SaveChanges();
        }
        public virtual Task<int> CommitAsync(CancellationToken cancellationToken = default)
        {
            return Context.SaveChangesAsync(cancellationToken);
		}
	}
}