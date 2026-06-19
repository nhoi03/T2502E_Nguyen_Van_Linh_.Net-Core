using System.ComponentModel.DataAnnotations;

namespace T2502E_Nguyen_Van_Linh_dotNet_Core.Models;

public class Rental
{
    public int RentalId { get; set; }

    public int CustomerId { get; set; }
    public Customer? Customer { get; set; }

    [DataType(DataType.Date)]
    public DateTime RentalDate { get; set; }

    [DataType(DataType.Date)]
    public DateTime ReturnDate { get; set; }

    public string Status { get; set; } = "Renting";

    public ICollection<RentalDetail>? RentalDetails { get; set; }
}