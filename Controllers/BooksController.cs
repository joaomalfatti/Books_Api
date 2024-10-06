using BooksApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace BooksApi.Controllers;
[Route("[controller]")]
[ApiController]
public class BooksController : ControllerBase
{
    private readonly List<ModelsBooks> _books = new List<ModelsBooks>();

    private int _nextId = 1;

    //Created Books
    [HttpPost]
    [ProducesResponseType(typeof(ModelsBooks), StatusCodes.Status200OK)]
    public IActionResult CreateBook([FromBody] ModelsBooks book)
    {
        book.Id = ++_nextId;
        _books.Add(book);

        return CreatedAtAction(nameof(GetBooks), new { id = book.Id }, book);

    }

    //ListBooks
    [HttpGet]
    public IActionResult ListBooks()
    {
        return Ok(_books);
    }

    //GetBooks
    [HttpGet("{id}")]
    public IActionResult GetBooks(int id)
    {
        var book = _books.FirstOrDefault(x => x.Id == id);
        if (book == null)
        {
            return NotFound();
        }
        return Ok(book);
    }
}
