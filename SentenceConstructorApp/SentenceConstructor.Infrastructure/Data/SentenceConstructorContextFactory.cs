using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SentenceConstructor.Infrastructure.Data
{
    public class SentenceConstructorContextFactory : IDesignTimeDbContextFactory<SentenceConstructorContext>
    {
        private readonly IConfiguration _config;
        public SentenceConstructorContextFactory(IConfiguration config)
        {
            _config = config;
        }
        public SentenceConstructorContext CreateDbContext(string[] args)
        {
           //var connectionString = _config["SentenceConnectionString"];
            var optionsBuilder = new DbContextOptionsBuilder<SentenceConstructorContext>();
            optionsBuilder.UseSqlServer("Server=localhost;Database=SentencesDb;User Id=sa;Password=Sentence1234!.;Trusted_Connection=True;TrustServerCertificate=Yes;Encrypt=False;");

            return new SentenceConstructorContext(optionsBuilder.Options);

        }
    }
}
