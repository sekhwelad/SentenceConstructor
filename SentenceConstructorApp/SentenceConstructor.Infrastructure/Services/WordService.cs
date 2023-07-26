using AutoMapper;
using SentenceConstructor.Core;
using SentenceConstructor.Core.Entities;
using SentenceConstructor.Core.Enums;
using SentenceConstructor.Core.Interfaces;
using SentenceConstructor.Core.Services;

namespace SentenceConstructor.Infrastructure.Services
{
    public class WordService : IWordService
    {
        private readonly IWordRepository _repository;

        public WordService(IWordRepository repository, IMapper mapper)
        {
            _repository = repository;
        }

        public async Task<Words> GetWords()
        {
            var adjectives = await GetWordsByTypeAsync((int)WordTypes.Adjective);
            var adverbs = await GetWordsByTypeAsync((int)WordTypes.Adverb);
            var conjunctions = await GetWordsByTypeAsync((int)WordTypes.Conjunction);
            var determiners = await GetWordsByTypeAsync((int)WordTypes.Determiner);
            var exclamations = await GetWordsByTypeAsync((int)WordTypes.Exclamation);
            var nouns = await GetWordsByTypeAsync((int)WordTypes.Noun);
            var prepositions = await GetWordsByTypeAsync((int)WordTypes.Preposition);
            var pronouns = await GetWordsByTypeAsync((int)WordTypes.Pronoun);
            var verbs = await GetWordsByTypeAsync((int)WordTypes.Verb);
     
            return new Words()
            {
                Addjectives = adjectives,
                Adverbs = adverbs,
                Conjunction = conjunctions,
                Determiner = determiners,
                Exclamation = exclamations,
                Noun = nouns,
                Preposition = prepositions,
                Pronoun = pronouns,
                Verb = verbs,
            };
        }

        public async Task<List<WordDTO>> GetWordsByTypeAsync(int id)
        {
            var data = await _repository.GetWordsAsync(id);
            return MapDomainToDto(data);
        }

        private List<WordDTO> MapDomainToDto(IReadOnlyList<Word> words) {
            return words.Select(x => new WordDTO() {
            Id = x.Id,
            WordTypeId = x.WordTypeId,
            Name = x.Name,})
                .ToList();
        }
    }
}
