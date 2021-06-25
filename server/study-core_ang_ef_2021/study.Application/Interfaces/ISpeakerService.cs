using study.Domain;
using System.Threading.Tasks;

namespace study.Application.Interfaces
{
    public interface ISpeakerService
    {
        Task<Speaker> AddSpeaker(Speaker model);
        Task<Speaker> UpdateSpeaker(int speakerId, Speaker model);
        Task<bool> DeleteSpeaker(int speakerId);
        Task<Speaker[]> GetAllSpeakerByNameAsync(string name, bool includeEvents);
        Task<Speaker[]> GetAllSpeakersAsync(bool includeEvents);
        Task<Speaker> GetSpeakerByIdAsync(int speakerId, bool includeEvents);
    }
}
