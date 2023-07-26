using SentenceConstructor.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SentenceConstructor.Core.Interfaces
{
    public interface ISentenceRepository
    {
        Task<Sentence> SaveSentenceAsync(Sentence sentence);
        Task<Sentence> GetSentence(int id);
        Task<Sentence[]> GetAllSentence();
    }
}
