using HotelManagement.DataAccess.Abstract;
using Microsoft.EntityFrameworkCore;

namespace HotelManagement.DataAccess.Concrete;

public abstract class Repository<T> : IRepository<T> where T : class
{
    protected AppDbContext Context { get; set; }

    public Repository(AppDbContext context)
    {
        Context = context;
    }

    public async Task<T> CreateAsync(T obj)
    {
        await Context.Set<T>().AddAsync(obj);
        return obj;
    }

    public T Update(T obj)
    {
        Context.Set<T>().Update(obj);
        return obj;
    }

    public void Delete(T obj) => Context.Set<T>().Remove(obj);

    public IQueryable<T> FindAll() => Context.Set<T>().AsNoTracking();

    public async Task<T> GetByIdAsync(int id) => await Context.Set<T>().FindAsync(id);
}