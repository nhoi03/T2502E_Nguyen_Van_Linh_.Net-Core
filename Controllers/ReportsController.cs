using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using T2502E_Nguyen_Van_Linh_dotNet_Core.Data;

namespace T2502E_Nguyen_Van_Linh_dotNet_Core.Controllers;

public class ReportsController : Controller
{
    private readonly AppDbContext _context;

    public ReportsController(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index(DateTime? fromDate, DateTime? toDate)
    {
        var query = _context.Rentals
            .Include(r => r.Customer)
            .Include(r => r.RentalDetails)!
            .ThenInclude(d => d.ComicBook)
            .AsQueryable();

        if (fromDate.HasValue)
        {
            query = query.Where(r => r.RentalDate >= fromDate.Value);
        }

        if (toDate.HasValue)
        {
            query = query.Where(r => r.ReturnDate <= toDate.Value);
        }

        ViewBag.FromDate = fromDate?.ToString("yyyy-MM-dd");
        ViewBag.ToDate = toDate?.ToString("yyyy-MM-dd");

        return View(await query.ToListAsync());
    }
}