﻿//namespace Events.WebApplication.Repositories
//{
//    using Events.Data;

//    public class UnitOfWork : IUnitOfWork
//    {
//        private readonly EventsDbContext eventsDbContext;

//        public UnitOfWork(EventsDbContext eventsDbContext)
//        {
//            this.eventsDbContext = eventsDbContext;
//            this.Events = new EventRepository(this.eventsDbContext);
//            this.Users = new UserRepository(this.eventsDbContext);
//            this.MatchStatistics = new MatchStatisticRepository(this.eventsDbContext);
//        }

//        public IEventRepository Events
//        {
//            get;
//            private set;
//        }

//        public IMatchStatisticRepository MatchStatistics
//        {
//            get;
//            private set;
//        }

//        public ITeamRepository Teams
//        {
//            get;
//            private set;
//        }

//        public IUserRespository Users
//        {
//            get;
//            private set;
//        }

//        public void Dispose()
//        {
//            this.eventsDbContext.Dispose();
//        }

//        public int SaveChanges()
//        {
//            return this.eventsDbContext.SaveChanges();
//        }
//    }
//}
