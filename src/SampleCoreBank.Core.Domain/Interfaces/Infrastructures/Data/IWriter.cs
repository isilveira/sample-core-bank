namespace SampleCoreBank.Core.Domain.Interfaces.Infrastructures.Data
{
	public interface IWriter
    {
        public IQueryable<TEntity> Query<TEntity>() where TEntity : class;

        public void Add<TEntity>(TEntity entity) where TEntity : class;

        public Task AddAsync<TEntity>(TEntity entity) where TEntity : class;

        public void AddRange<TEntity>(params TEntity[] entities) where TEntity : class;

        public Task AddRangeAsync<TEntity>(params TEntity[] entities) where TEntity : class;
        public void Remove<TEntity>(TEntity entity) where TEntity : class;
        public void RemoveRange<TEntity>(params TEntity[] entities) where TEntity : class;
        public int Commit();
        public Task<int> CommitAsync(CancellationToken cancellationToken = default);
	}
}