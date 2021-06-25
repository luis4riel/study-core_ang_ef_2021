using Microsoft.EntityFrameworkCore;
using study.Domain;
using study.Repository.Contexts;
using study.Repository.Interfaces;
using System.Linq;
using System.Threading.Tasks;

namespace study.Repository
{
    public class EventRepository : IEventRepository
    {
        private readonly EventsContext _eventsContext;
        public EventRepository(EventsContext eventsContext)
        {
            _eventsContext = eventsContext;
            _eventsContext.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        public async Task<Event[]> GetAllEventsAsync(bool includeSpeaker)
        {
            IQueryable<Event> query = MakeEventQuery(includeSpeaker);

            return await query.OrderBy(e => e.Id).ToArrayAsync();
        }

        public async Task<Event[]> GetAllEventsByThemeAsync(string theme, bool includeSpeaker)
        {
            IQueryable<Event> query = MakeEventQuery(includeSpeaker);

            query = query.OrderBy(e => e.Id)
                .Where(e => e.Theme.ToLower().Contains(theme.ToLower()));

            return await query.ToArrayAsync();
        }

        public async Task<Event> GetEventByIdAsync(int eventId, bool includeSpeaker)
        {
            IQueryable<Event> query = MakeEventQuery(includeSpeaker);

            query = query.Where(e => e.Id.Equals(eventId));

            return await query.FirstOrDefaultAsync();
        }

        private IQueryable<Event> MakeEventQuery(bool includeSpeaker)
        {
            IQueryable<Event> query = _eventsContext.Events.Include(e => e.Lotes).Include(e => e.SocialNetworks);

            if (includeSpeaker)
                query = query.Include(e => e.SpeakerEvents).ThenInclude(se => se.Speaker);

            return query;
        }
    }
}