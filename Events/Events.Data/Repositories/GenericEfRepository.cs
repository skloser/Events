﻿using System.Data.Entity;

namespace Data.Repositories
{
   
    public class GenericEfRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private DbContext dbContext;
        private IDbSet<TEntity> entitySet;

        public GenericEfRepository(DbContext dbContext)
        {
            this.dbContext = dbContext;
            this.entitySet = dbContext.Set<TEntity>();
        }

        public IDbSet<TEntity> EntitySet
        {
            get { return this.entitySet; }
        }

        public System.Linq.IQueryable<TEntity> All()
        {
            return this.entitySet;
        }



        public TEntity Find(object id)
        {
            return this.entitySet.Find(id);
        }

        public TEntity Add(TEntity entity)
        {
            return this.ChangeState(entity, EntityState.Added);
        }

        public TEntity Update(TEntity entity)
        {
            return this.ChangeState(entity, EntityState.Modified);
            SaveChanges();
        }

        public void Remove(TEntity entity)
        {
            this.ChangeState(entity, EntityState.Deleted);
            SaveChanges();
        }

        public TEntity Remove(object id)
        {
            var entity = this.Find(id);
            this.Remove(entity);
            SaveChanges();
            return entity;
        }

        public void SaveChanges()
        {
            this.dbContext.SaveChanges();
        }

        private TEntity ChangeState(TEntity entity, EntityState state)
        {
            var entry = this.dbContext.Entry(entity);
            if (entry.State == EntityState.Detached)
            {
                this.entitySet.Attach(entity);
            }

            entry.State = state;
            SaveChanges();
            return entity;
        }
    }
}
