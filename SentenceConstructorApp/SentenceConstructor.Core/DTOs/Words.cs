using SentenceConstructor.Core.Enums;

namespace SentenceConstructor.Core
{
    public class Words
    {
        public List<WordDTO> Addjectives { get; set; }
        public List<WordDTO> Adverbs { get; set; }
        public List<WordDTO> Conjunction { get; set; }
        public List<WordDTO> Determiner { get; set; }
        public List<WordDTO> Exclamation { get; set; }
        public List<WordDTO> Noun { get; set; }
        public List<WordDTO> Preposition { get; set; }
        public List<WordDTO> Pronoun { get; set; }
        public List<WordDTO> Verb { get; set; }
    }
}