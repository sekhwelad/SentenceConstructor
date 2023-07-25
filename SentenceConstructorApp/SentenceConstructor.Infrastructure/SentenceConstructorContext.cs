using Microsoft.EntityFrameworkCore;
using SentenceConstructor.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SentenceConstructor.Infrastructure
{
    public class SentenceConstructorContext : DbContext
    {
        public SentenceConstructorContext(DbContextOptions<SentenceConstructorContext> options) : base(options)
        {

        }

        public DbSet<Sentence> Sentences { get; set; }
        public DbSet<Word> Words { get; set; }
        public DbSet<WordType> WordTypes { get; set; }
    }
}
