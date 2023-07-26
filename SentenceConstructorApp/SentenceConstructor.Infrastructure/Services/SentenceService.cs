using SentenceConstructor.Core.Entities;
using SentenceConstructor.Core.Interfaces;
using SentenceConstructor.Core.Services;

namespace SentenceConstructor.Infrastructure.Services
{
    public class SentenceService : ISentenceService
    {
       private readonly ISentenceRepository _sentenceRepository;

        public SentenceService(ISentenceRepository sentenceRepository)
        {
            _sentenceRepository = sentenceRepository;
        }

        public Task<Sentence[]> GetAllSentences()
        {
            return _sentenceRepository.GetAllSentence();
        }

        public Task<Sentence> GetSentence(int id)
        {
          return  _sentenceRepository.GetSentence(id);
        }

        public async Task<Sentence> SaveSentence(Sentence sentence)
        {
           return await _sentenceRepository.SaveSentenceAsync(sentence); ;
        }
    }
}
