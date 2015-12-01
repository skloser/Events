using System;
using System.Data.Entity.Validation;
using System.Linq;

namespace Events.Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly EventsDbContext eventsDbContext;

        public UnitOfWork(EventsDbContext eventsDbContext)
        {
            this.eventsDbContext = eventsDbContext;
            this.Events = new EventRepository(this.eventsDbContext);
            this.Users = new UserRepository(this.eventsDbContext);
        }

        public IEventRepository Events
        {
            get;
            private set;
        }

     

        public ITeamRepository Teams
        {
            get;
            private set;
        }

        public IUserRespository Users
        {
            get;
            private set;
        }

        public void Dispose()
        {
            this.eventsDbContext.Dispose();
        }

        public int SaveChanges()
        {
            try
            {
                return this.eventsDbContext.SaveChanges();
            }
            catch (DbEntityValidationException ex)
        {
                
            // Retrieve the error messages as a list of strings.
            var errorMessages = ex.EntityValidationErrors
                    .SelectMany(x => x.ValidationErrors)
                    .Select(x => x.ErrorMessage);

            // Join the list to a single string.
            var fullErrorMessage = string.Join("; ", errorMessages);

            // Combine the original exception message with the new one.
            var exceptionMessage = string.Concat(ex.Message, " The validation errors are: ", fullErrorMessage);
     // Throw a new DbEntityValidationException with the improved exception message.

            throw new DbEntityValidationException(exceptionMessage, ex.EntityValidationErrors);
        }

            }
        }
}
