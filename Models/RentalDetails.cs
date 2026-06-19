namespace T2502E_Nguyen_Van_Linh_dotNet_Core.Models;

public class RentalDetail
{
    public int RentalDetailId { get; set; }

    public int RentalId { get; set; }
    public Rental? Rental { get; set; }

    public int ComicBookId { get; set; }
    public ComicBook? ComicBook { get; set; }

    public int Quantity { get; set; }

    public decimal PricePerDay { get; set; }
}