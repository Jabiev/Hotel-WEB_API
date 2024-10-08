﻿using HotelManagement.Core.Entities;

namespace HotelManagement.Business.Interfaces;

public interface IHotelService
{
    Task<Hotel> Create(Hotel hotel);
    Task<Hotel> Update(Hotel newHotel);
    Task Delete(int id);
    List<Hotel> GetAll();
    Task<Hotel> GetById(int id);
    List<Hotel> SearchByName(string? search);
    List<Hotel> SearchByRegion(string? search);
}