using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

using System;
using System.Collections.Generic;
using System.Data.Entity;
using Events.Model;
using Events.Model.Statistics;
using Events.Data;
using Data.Repositories;

namespace Data.UnitOfWork
{
    public class ApplicationData : IApplicationData
    {
        private readonly DbContext dbContext;

        private readonly IDictionary<Type, object> repositories;

        private IUserStore<User> userStore;

        public ApplicationData()
            : this(new EventsDbContext())
        {
        }

        public ApplicationData(DbContext dbContext)
        {
            this.dbContext = dbContext;
            this.repositories = new Dictionary<Type, object>();
        }

        public IRepository<User> Users
        {
            get { return this.GetRepository<User>(); }
        }


        public IRepository<Event> Events
        {
            get { return this.GetRepository<Event>(); }
        }

        public IRepository<MatchStatistic> MatchStatistics
        {
            get { return this.GetRepository<MatchStatistic>(); }
        }

        public IRepository<Team> UserTeams
        {
            get { return this.GetRepository<Team>(); }
        }

        public IUserStore<User> UserStore
        {
            get
            {
                if (this.userStore == null)
                {
                    this.userStore = new UserStore<User>(this.dbContext);
                }

                return this.userStore;
            }
        }

        

        public void SaveChanges()
        {
            this.dbContext.SaveChanges();
        }

        private IRepository<T> GetRepository<T>() where T : class
        {
            if (!this.repositories.ContainsKey(typeof(T)))
            {
                var type = typeof(GenericEfRepository<T>);
                this.repositories.Add(
                    typeof(T),
                    Activator.CreateInstance(type, this.dbContext));
            }

            return (IRepository<T>)this.repositories[typeof(T)];
        }
    }
}