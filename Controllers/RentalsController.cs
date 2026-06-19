using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using T2502E_Nguyen_Van_Linh_dotNet_Core.Data;
using T2502E_Nguyen_Van_Linh_dotNet_Core.Models;

namespace T2502E_Nguyen_Van_Linh_dotNet_Core.Controllers;

public class RentalsController : Controller
{
    private readonly AppDbContext _context;

    public RentalsController(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        var rentals = await _context.Rentals
            .Include(r => r.Customer)
            .Include(r => r.RentalDetails)!
            .ThenInclude(d => d.ComicBook)
            .ToListAsync();

        return View(rentals);
    }

    public async Task<IActionResult> Create()
    {
        ViewBag.Customers = new SelectList(await _context.Customers.ToListAsync(), "CustomerId", "FullName");
        ViewBag.ComicBooks = new SelectList(await _context.ComicBooks.ToListAsync(), "ComicBookId", "Title");

        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(int customerId, DateTime rentalDate, DateTime returnDate, int comicBookId, int quantity)
    {
        var comicBook = await _context.ComicBooks.FindAsync(comicBookId);

        if (comicBook == null)
        {
            return NotFound();
        }

        var rental = new Rental
        {
            CustomerId = customerId,
            RentalDate = rentalDate,
            ReturnDate = returnDate,
            Status = "Renting"
        };

        _context.Rentals.Add(rental);
        await _context.SaveChangesAsync();

        var detail = new RentalDetail
        {
            RentalId = rental.RentalId,
            ComicBookId = comicBookId,
            Quantity = quantity,
            PricePerDay = comicBook.PricePerDay
        };

        _context.RentalDetails.Add(detail);
        await _context.SaveChangesAsync();

        return RedirectToAction(nameof(Index));
    }
}