using study.Repository.Contexts;
using study.Repository.Interfaces;
using System.Threading.Tasks;

namespace study.Repository
{
    public class BaseRepository : IBaseRepository
    {
        private readonly EventsContext _eventsContext;

        public BaseRepository(EventsContext eventsContext)
        {
            _eventsContext = eventsContext;
            _eventsContext.ChangeTracker.QueryTrackingBehavior = Microsoft.EntityFrameworkCore.QueryTrackingBehavior.NoTracking;
        }

        public void Add<T>(T entity) where T : class
        {
            _eventsContext.Add(entity);
        }

        public void Update<T>(T entity) where T : class
        {
            _eventsContext.Update(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _eventsContext.Remove(entity);
        }

        public void DeleteRange<T>(T[] entity) where T : class
        {
            _eventsContext.RemoveRange(entity);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _eventsContext.SaveChangesAsync()) > 0;
        }
    }
}
