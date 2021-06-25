using study.Application.Interfaces;
using study.Domain;
using study.Repository.Interfaces;
using System;
using System.Threading.Tasks;

namespace study.Application.Services
{
    public class SpeakerService : ISpeakerService
    {
        private readonly IBaseRepository _baseRepository;
        private readonly ISpeakerRepository _speakerRepository;

        public SpeakerService(IBaseRepository baseRepository, ISpeakerRepository speakerRepository)
        {
            _baseRepository = baseRepository;
            _speakerRepository = speakerRepository;
        }

        public async Task<Speaker> AddSpeaker(Speaker model)
        {
            try
            {
                _baseRepository.Add(model);

                if (await _baseRepository.SaveChangesAsync())
                    return await _speakerRepository.GetSpeakerByIdAsync(model.Id, true);

                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Speaker> UpdateSpeaker(int speakerId, Speaker model)
        {
            try
            {
                var speaker = _speakerRepository.GetSpeakerByIdAsync(speakerId, true);
                if (speaker.Equals(null)) return null;

                model.Id = speaker.Result.Id;

                _baseRepository.Update(model);

                if (await _baseRepository.SaveChangesAsync())
                    return await _speakerRepository.GetSpeakerByIdAsync(speakerId, true);

                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeleteSpeaker(int speakerId)
        {
            try
            {
                var speaker = _speakerRepository.GetSpeakerByIdAsync(speakerId, true);
                if (speaker.Equals(null))
                    throw new Exception("Speaker not found");

                _baseRepository.Delete(speaker.Result);

                return await _baseRepository.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Speaker[]> GetAllSpeakerByNameAsync(string name, bool includeEvents)
        {
            try
            {
                var events = await _speakerRepository.GetAllSpeakerByNameAsync(name, includeEvents);

                if (events.Equals(null))
                    return null;

                return events;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Speaker[]> GetAllSpeakersAsync(bool includeEvents)
        {
            try
            {
                var speakers = await _speakerRepository.GetAllSpeakersAsync(includeEvents);

                if (speakers.Equals(null))
                    return null;

                return speakers;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Speaker> GetSpeakerByIdAsync(int speakerId, bool includeEvents)
        {
            try
            {
                var events = await _speakerRepository.GetSpeakerByIdAsync(speakerId, includeEvents);

                if (events.Equals(null))
                    return null;

                return events;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}