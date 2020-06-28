using Abp.Domain.Entities;
using Abp.EntityFramework;
using Abp.EntityFramework.Repositories;

namespace ST.EntityFramework.Repositories
{
    public abstract class STRepositoryBase<TEntity, TPrimaryKey> : EfRepositoryBase<STDbContext, TEntity, TPrimaryKey>
        where TEntity : class, IEntity<TPrimaryKey>
    {
        protected STRepositoryBase(IDbContextProvider<STDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        //add common methods for all repositories
    }

    public abstract class STRepositoryBase<TEntity> : STRepositoryBase<TEntity, int>
        where TEntity : class, IEntity<int>
    {
        protected STRepositoryBase(IDbContextProvider<STDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        //do not add any method here, add to the class above (since this inherits it)
    }
}
