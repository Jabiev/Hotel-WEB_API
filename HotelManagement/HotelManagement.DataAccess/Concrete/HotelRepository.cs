using HotelManagement.Core.Entities;
using HotelManagement.DataAccess.Abstract;
using Microsoft.EntityFrameworkCore;

namespace HotelManagement.DataAccess.Concrete;

public class HotelRepository : Repository<Hotel>, IHotelRepository
{
    public HotelRepository(AppDbContext appDbContext) : base(appDbContext)
    {
    }
}
