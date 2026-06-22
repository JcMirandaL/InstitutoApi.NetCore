

namespace InstitutoApp.Common.Interfaces
{
    public interface IGenericRepository <E>
    {
        Task<List<E>> GetAllAsync();

        Task<E?> GetByIdAsync(int id);

        Task<E> CreateAsync(E entity);

        Task<E> UpdateAsync(E entity);

        Task<bool> DeleteAsync(int id);
    }
}
