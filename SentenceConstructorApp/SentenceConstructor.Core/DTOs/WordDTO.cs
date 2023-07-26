using SentenceConstructor.Core.Entities;

namespace SentenceConstructor.Core
{
    public class WordDTO :BaseEntity
    {
        public string Name { get; set; }
        public int WordTypeId { get; set; }

    }
}
