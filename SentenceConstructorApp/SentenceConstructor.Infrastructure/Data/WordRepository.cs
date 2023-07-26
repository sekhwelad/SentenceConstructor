using Microsoft.EntityFrameworkCore;
using SentenceConstructor.Core.Entities;
using SentenceConstructor.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SentenceConstructor.Infrastructure.Data
{
    public class WordRepository : IWordRepository
    {
        private readonly SentenceConstructorContext _context;

        public WordRepository(SentenceConstructorContext context)
        {
            _context = context;
        }
        public async Task<IReadOnlyList<Word>> GetWordsAsync(int id)
        {
            return await _context.Words.Where(x=> x.WordTypeId == id).ToListAsync() ;
        }
    }
}
