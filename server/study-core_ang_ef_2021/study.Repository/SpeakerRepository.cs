using Microsoft.EntityFrameworkCore;
using study.Domain;
using study.Repository.Contexts;
using study.Repository.Interfaces;
using System.Linq;
using System.Threading.Tasks;

namespace study.Repository
{
    public class SpeakerRepository : ISpeakerRepository
    {
        private readonly EventsContext _eventsContext;
        public SpeakerRepository(EventsContext eventsContext)
        {
            _eventsContext = eventsContext;
            _eventsContext.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        public async Task<Speaker[]> GetAllSpeakerByNameAsync(string name, bool includeEvents = false)
        {
            IQueryable<Speaker> query = MakeSpeakerQuery(includeEvents);

            if (!string.IsNullOrEmpty(name))
                query = query.Where(s => s.Name.ToLower().Contains(name.ToLower()));

            return await query.OrderBy(e => e.Id).ToArrayAsync();
        }

        public async Task<Speaker[]> GetAllSpeakersAsync(bool includeEvents = false)
        {
            IQueryable<Speaker> query = MakeSpeakerQuery(includeEvents);

            return await query.OrderBy(e => e.Id).ToArrayAsync();
        }

        public Task<Speaker> GetSpeakerByIdAsync(int speakerId, bool includeEvents = false)
        {
            IQueryable<Speaker> query = MakeSpeakerQuery(includeEvents);

            return query.Where(s => s.Id.Equals(speakerId)).FirstOrDefaultAsync();
        }

        private IQueryable<Speaker> MakeSpeakerQuery(bool includeEvents)
        {
            IQueryable<Speaker> query = _eventsContext.Speakers.Include(e => e.SocialNetworks);

            if (includeEvents)
                query = query.Include(e => e.SpeakerEvents).ThenInclude(se => se.Event);

            return query;
        }
    }
}