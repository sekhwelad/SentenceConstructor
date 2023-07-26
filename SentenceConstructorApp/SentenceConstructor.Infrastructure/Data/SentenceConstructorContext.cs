using Microsoft.EntityFrameworkCore;
using SentenceConstructor.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SentenceConstructor.Infrastructure.Data
{
    public class SentenceConstructorContext : DbContext
    {
        public SentenceConstructorContext(DbContextOptions<SentenceConstructorContext> options) : base(options)
        {

        }

        public DbSet<Sentence> Sentences { get; set; }
        public DbSet<Word> Words { get; set; }
        public DbSet<WordType> WordTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

    }
}
