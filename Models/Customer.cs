
using System.ComponentModel.DataAnnotations;

namespace T2502E_Nguyen_Van_Linh_dotNet_Core.Models;

public class Customer
{
    public int CustomerId { get; set; }

    [Required]
    public string FullName { get; set; } = string.Empty;

    [Required]
    public string PhoneNumber { get; set; } = string.Empty;

    public DateTime RegistrationDate { get; set; } = DateTime.Now;

    public ICollection<Rental>? Rentals { get; set; }
}