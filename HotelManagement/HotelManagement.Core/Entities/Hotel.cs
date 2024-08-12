using HotelManagement.Core.IEntities;
using System.ComponentModel.DataAnnotations;

namespace HotelManagement.Core.Entities;

public class Hotel : IEntity
{
    public int Id { get; set; }

    [MaxLength(50)]
    [Required]
    public string? Name { get; set; }

    [MaxLength(50)]
    [Required]
    public string? Region { get; set; }

    //public override bool Equals(object? obj)
    //{
    //    if (obj is Hotel hotel)
    //    {
    //        return this.Id == hotel.Id && this.Name == hotel.Name && this.Region == hotel.Region;
    //    }
    //    return false;
    //}

    //public override int GetHashCode()
    //{
    //    return HashCode.Combine(Id, Name, Region);
    //}
}