using HotelManagement.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace HotelManagement.DataAccess;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }
    /*protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server = .; Database = HotelManagement; Trusted_Connection = True; TrustServerCertificate=True;");
    }*/
    public DbSet<Hotel> Hotels { get; set; }
}