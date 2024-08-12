using HotelManagement.Business.Interfaces;
using HotelManagement.Core.Entities;
using HotelManagement.DataAccess.Abstract;
using HotelManagement.DataAccess.Concrete;

namespace HotelManagement.Business.Implementations;

public class HotelService : IHotelService
{
    IRepositoryWrapper _wrapper;

    public HotelService(IRepositoryWrapper wrapper)
    {
        _wrapper = wrapper;
    }

    public async Task<Hotel> Create(Hotel hotel)
    {
        if (hotel is null)
            throw new ArgumentNullException("The object can't be null");
        if ((await _wrapper.Hotel.GetByIdAsync(hotel.Id)) is not null)
            throw new Exception("The id already exists, THERE IS NO NEED ANYWAY for ID");
        if (GetAll().FirstOrDefault(h => h.Name == hotel.Name && h.Region == hotel.Region) is not null)
            throw new Exception("The object already exists");
        await _wrapper.Hotel.CreateAsync(hotel);
        await _wrapper.SaveAsync();
        return hotel;
    }

    public async Task Delete(int id)
    {
        if (id < 1)
            throw new ArgumentOutOfRangeException("ID can't be less than 1");
        var hotel = _wrapper.Hotel.FindAll().FirstOrDefault(h => h.Id == id);
        if (hotel is null)
            throw new Exception("The object had not been found");
        _wrapper.Hotel.Delete(hotel);
        await _wrapper.SaveAsync();
    }

    public List<Hotel> GetAll() => _wrapper.Hotel.FindAll().ToList();

    public async Task<Hotel> GetById(int id)
    {
        if (id < 1)
            throw new ArgumentOutOfRangeException("ID can't be less than 1");
        var hotel = _wrapper.Hotel.FindAll().FirstOrDefault(h => h.Id == id);
        if (hotel is null)
            throw new Exception("The object with that id wasn't found");
        return hotel;
    }

    public List<Hotel> SearchByName(string? search)
    {
        if (string.IsNullOrEmpty(search))
            throw new Exception("That can't be null or empty");
        var hotels = GetAll().FindAll(h => h.Name.Contains(search, StringComparison.OrdinalIgnoreCase));
        if (hotels is null || !hotels.Any())
            throw new Exception("The objects(or object) with that name were not found");
        return hotels;
    }

    public List<Hotel> SearchByRegion(string regionName)
    {
        if (string.IsNullOrEmpty(regionName))
            throw new Exception("Search term cannot be null or empty.");
        var hotels = _wrapper.Hotel.FindByCondition(h => h.Region.ToUpper().Equals(regionName.ToUpper())).ToList();
        if (hotels is null || !hotels.Any())
            throw new Exception("The objects(or object) with that name were not found");
        return hotels;
    }

    public async Task<Hotel> Update(Hotel newHotel)
    {
        if (newHotel is null)
            throw new ArgumentNullException("The object can't be null");
        //var updatingHotel = 
        await GetById(newHotel.Id);
        if (GetAll().Find(h => h.Name == newHotel.Name && h.Region == newHotel.Region) is not null)
            throw new Exception("The object already exist");
        //updatingHotel.Name = newHotel.Name;
        //updatingHotel.Region = newHotel.Region;
        _wrapper.Hotel.Update(newHotel);
        await _wrapper.SaveAsync();
        return newHotel;
    }
}