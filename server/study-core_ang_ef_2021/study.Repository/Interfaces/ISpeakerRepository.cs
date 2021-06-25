using study.Domain;
using System.Threading.Tasks;

namespace study.Repository.Interfaces
{
    public interface ISpeakerRepository
    {
        Task<Speaker[]> GetAllSpeakerByNameAsync(string name, bool includeEvents);
        Task<Speaker[]> GetAllSpeakersAsync(bool includeEvents);
        Task<Speaker> GetSpeakerByIdAsync(int speakerId, bool includeEvents);
    }
}
