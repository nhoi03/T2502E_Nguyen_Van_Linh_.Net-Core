
using System.ComponentModel.DataAnnotations;

namespace T2502E_Nguyen_Van_Linh_dotNet_Core.Models;

public class ComicBook
{
    public int ComicBookId { get; set; }

    [Required]
    public string Title { get; set; } = string.Empty;

    [Required]
    public string Author { get; set; } = string.Empty;

    public decimal PricePerDay { get; set; }

    public ICollection<RentalDetail>? RentalDetails { get; set; }
}