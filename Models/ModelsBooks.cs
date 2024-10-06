using Microsoft.AspNetCore.Mvc;

namespace BooksApi.Models;

[Route("[controller]")]
[ApiController]

public class ModelsBooks : ControllerBase
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Author { get; set; } = string.Empty;
    public string Genre {  get; set; } = string.Empty;
    public decimal Value { get; set; }
    public int QuantityInStock { get; set; }

}
