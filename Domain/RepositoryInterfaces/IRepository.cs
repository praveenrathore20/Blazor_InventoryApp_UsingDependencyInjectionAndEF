using System.Linq.Expressions;

namespace Domain.RepositoryInterfaces
{
    public interface IRepository<T>
    {
        IEnumerable<T> GetAll();
        Task<IEnumerable<T>> GetAllAsync();
        T GetById(int id);
        Task<T> GetByIdAsync(int id);
        T Add(T entity);
        Task<T> AddAsync(T entity);
        T Update(T entity);
        Task<T> UpdateAsync(T entity);
        int Delete(int id);
        Task<int> DeleteAsync(int id);
        Task<ICollection<T>> FindAllAsync(Expression<Func<T, bool>> match);
    }
}
