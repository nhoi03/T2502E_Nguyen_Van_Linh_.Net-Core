
using Microsoft.EntityFrameworkCore;
using T2502E_Nguyen_Van_Linh_dotNet_Core.Models;

namespace T2502E_Nguyen_Van_Linh_dotNet_Core.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Customer> Customers => Set<Customer>();
    public DbSet<ComicBook> ComicBooks => Set<ComicBook>();
    public DbSet<Rental> Rentals => Set<Rental>();
    public DbSet<RentalDetail> RentalDetails => Set<RentalDetail>();
}