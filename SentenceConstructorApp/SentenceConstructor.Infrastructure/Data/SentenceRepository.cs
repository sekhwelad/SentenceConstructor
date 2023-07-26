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
    public class SentenceRepository : ISentenceRepository
    {
        private readonly SentenceConstructorContext _context;

        public SentenceRepository(SentenceConstructorContext context)
        {
            _context = context;
        }
        public async Task<Sentence> SaveSentenceAsync(Sentence word)
        {
            var d  = await _context.Sentences.AddAsync(word);
            await  _context.SaveChangesAsync();

            return d.Entity;
        }

        public async Task<Sentence> GetSentence(int id)
        {
          return await _context.Sentences.FindAsync(id);
        }

        public async Task<Sentence[]> GetAllSentence()
        {
            return await _context.Sentences.ToArrayAsync();
        }
    }
}
