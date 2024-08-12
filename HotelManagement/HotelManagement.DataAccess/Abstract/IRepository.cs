namespace HotelManagement.DataAccess.Abstract;

public interface IRepository<T> where T : class
{
    Task<T> CreateAsync(T obj);
    T Update(T obj);
    void Delete(T obj);
    IQueryable<T> FindAll();
    Task<T> GetByIdAsync(int id);
}