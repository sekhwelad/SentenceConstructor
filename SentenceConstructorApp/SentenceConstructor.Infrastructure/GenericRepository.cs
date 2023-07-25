using SentenceConstructor.Core.Entities;
using SentenceConstructor.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SentenceConstructor.Infrastructure
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        public Task<IReadOnlyList<T>> GetByIdAsync()
        {
            throw new NotImplementedException();
        }
    }
}
