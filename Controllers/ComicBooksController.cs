using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using T2502E_Nguyen_Van_Linh_dotNet_Core.Data;
using T2502E_Nguyen_Van_Linh_dotNet_Core.Models;

namespace T2502E_Nguyen_Van_Linh_dotNet_Core.Controllers;

public class ComicBooksController : Controller
{
    private readonly AppDbContext _context;

    public ComicBooksController(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        return View(await _context.ComicBooks.ToListAsync());
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(ComicBook comicBook)
    {
        if (!ModelState.IsValid) return View(comicBook);

        _context.ComicBooks.Add(comicBook);
        await _context.SaveChangesAsync();

        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Edit(int id)
    {
        var comicBook = await _context.ComicBooks.FindAsync(id);
        if (comicBook == null) return NotFound();

        return View(comicBook);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(ComicBook comicBook)
    {
        if (!ModelState.IsValid) return View(comicBook);

        _context.ComicBooks.Update(comicBook);
        await _context.SaveChangesAsync();

        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Delete(int id)
    {
        var comicBook = await _context.ComicBooks.FindAsync(id);
        if (comicBook == null) return NotFound();

        _context.ComicBooks.Remove(comicBook);
        await _context.SaveChangesAsync();

        return RedirectToAction(nameof(Index));
    }
}