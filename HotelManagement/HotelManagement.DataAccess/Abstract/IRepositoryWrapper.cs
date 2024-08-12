namespace HotelManagement.DataAccess.Abstract;

public interface IRepositoryWrapper
{
    IHotelRepository Hotel { get; }
    Task SaveAsync();
}