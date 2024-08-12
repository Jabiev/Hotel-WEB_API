using HotelManagement.Core.Entities;
using System.Linq.Expressions;

namespace HotelManagement.DataAccess.Abstract;

public interface IHotelRepository : IRepository<Hotel>
{
    IQueryable<Hotel> FindByCondition(Expression<Func<Hotel, bool>> expression);
}