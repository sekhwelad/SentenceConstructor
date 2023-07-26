using SentenceConstructor.Core.Entities;

namespace SentenceConstructor.Core.Services
{
    public interface IWordService
    {
       Task<List<WordDTO>> GetWordsByTypeAsync(int id);

        Task<Words> GetWords();
        //Task<Sentence> SaveSentence(Sentence word);

    }
}
