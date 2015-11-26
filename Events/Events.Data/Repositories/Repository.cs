namespace Events.Data.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Linq.Expressions;

    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly DbContext context;
        private IDbSet<TEntity> entitySet;
        public Repository(DbContext context)
        {
            this.context = context;
            this.entitySet = Context.Set<TEntity>();
        }
       
        protected DbContext Context
        {
            get { return this.context; }
        }

        public void Add(TEntity entity)
        {
            this.context.Set<TEntity>().Add(entity);
        }

        public void AddRange(IEnumerable<TEntity> entities)
        {
            this.context.Set<TEntity>().AddRange(entities);
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return this.context.Set<TEntity>().Where(predicate);
        }

        public TEntity Get(int id)
        {
            return this.context.Set<TEntity>().Find(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return this.context.Set<TEntity>().ToList();
        }

        public void Remove(TEntity entity)
        {
            this.context.Set<TEntity>().Remove(entity);
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            this.context.Set<TEntity>().RemoveRange(entities);
        }

        

        public TEntity Update(TEntity entity)
        {
            return this.ChangeState(entity, EntityState.Modified);
        }

        private TEntity ChangeState(TEntity entity, EntityState state)
        {
            var entry = this.Context.Entry(entity);
            if (entry.State == EntityState.Detached)
            {
                this.entitySet.Attach(entity);
            }

            entry.State = state;
            return entity;
        }
    }
}
