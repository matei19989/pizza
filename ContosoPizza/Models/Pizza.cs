using System.ComponentModel.DataAnnotations;

namespace ContosoPizza.Models;

public class Pizza
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Pizza name is required")]
    [StringLength(100, MinimumLength = 3, ErrorMessage = "Pizza name must be between 3 and 100 characters")]
    public string? Name { get; set; }
    public PizzaSize Size { get; set; }
    public bool IsGlutenFree { get; set; }
    [StringLength(100, ErrorMessage = "Description can't be longer than 100 characters")]
    public string Description { get; set; } = string.Empty;

    [Range(0.01, 9999.99)]
    [Required]
    public decimal Price { get; set; }
}

public enum PizzaSize { Small, Medium, Large }