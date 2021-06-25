using study.Domain;
using System.Threading.Tasks;

namespace study.Repository.Interfaces
{
    public interface IEventRepository
    {
        Task<Event[]> GetAllEventsByThemeAsync(string theme, bool includeSpeaker);
        Task<Event[]> GetAllEventsAsync(bool includeSpeaker);
        Task<Event> GetEventByIdAsync(int eventId, bool includeSpeaker);
    }
}
