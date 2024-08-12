using HotelManagement.Core.Entities;
using HotelManagement.DataAccess.Abstract;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace HotelManagement.DataAccess.Concrete;

public class HotelRepository : Repository<Hotel>, IHotelRepository
{
    public HotelRepository(AppDbContext appDbContext) : base(appDbContext)
    {
    }

    public IQueryable<Hotel> FindByCondition(Expression<Func<Hotel, bool>> expression) => Context.Set<Hotel>().Where(expression).AsNoTracking();
}