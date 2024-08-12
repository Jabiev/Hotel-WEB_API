using HotelManagement.Business.Implementations;
using HotelManagement.Business.Interfaces;
using HotelManagement.DataAccess.Abstract;
using HotelManagement.DataAccess.Concrete;

namespace HotelManagement.API.Extensions;

public static class ServiceExtension
{
    public static void ConfigureHotelService(this IServiceCollection services)
    {
        services.AddScoped<IHotelService, HotelService>();
    }

    public static void ConfigureRepositoryWrapper(this IServiceCollection services)
    {
        services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
    }
}