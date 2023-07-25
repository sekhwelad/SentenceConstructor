using SentenceConstructor.Core.Entities;

namespace SentenceConstructor.Core.Interfaces
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        Task<IReadOnlyList<T>> GetByIdAsync();
    }
}
