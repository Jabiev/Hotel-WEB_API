using HotelManagement.DataAccess.Abstract;

namespace HotelManagement.DataAccess.Concrete;

public class RepositoryWrapper : IRepositoryWrapper
{
    private AppDbContext _context;
    private IHotelRepository _hotel;

    public RepositoryWrapper(AppDbContext context)
    {
        _context = context;
    }

    public IHotelRepository Hotel
    {
        get
        {
            if (_hotel == null)
                _hotel = new HotelRepository(_context);
            return _hotel;
        }
    }

    public async Task SaveAsync()
    {
        await _context.SaveChangesAsync();
    }
}