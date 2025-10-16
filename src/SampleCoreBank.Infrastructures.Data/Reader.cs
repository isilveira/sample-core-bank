using Microsoft.EntityFrameworkCore;
using SampleCoreBank.Core.Domain.Interfaces.Infrastructures.Data;

namespace SampleCoreBank.Infrastructures.Data
{
    public class Reader : IReader
    {
        protected DbContext Context { get; private set; }
        public Reader(DbContext context)
        {
            Context = context;
        }
        public IQueryable<TEntity> Query<TEntity>() where TEntity : class
        {
            return Context
                .Set<TEntity>()
                .AsQueryable()
                .AsNoTracking();
        }
    }
}