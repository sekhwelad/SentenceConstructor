using SentenceConstructor.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SentenceConstructor.Core.Services
{
    public interface ISentenceService
    {
        Task<Sentence> SaveSentence(Sentence sentence);
        Task<Sentence[]> GetAllSentences();
        Task<Sentence> GetSentence(int id);
    }
}
