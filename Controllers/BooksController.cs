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
    [ProducesResponseType(typeof(ModelsBooks), StatusCodes.Status201Created)]
    public IActionResult CreateBook([FromBody] ModelsBooks book)
    {
        book.Id = _nextId++;
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
    [HttpGet]
    [Route("{Id}")]
    [ProducesResponseType(typeof(ModelsBooks), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult GetBooks([FromRoute]int Id)
    {
        var book = _books.FirstOrDefault(x => x.Id == Id);
        if (book == null)
        {
            return NotFound();
        }
        return Ok(book);
    }

    //PutBooks
    [HttpPut]
    [Route("{Id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult PutBooks([FromRoute]int Id, ModelsBooks bookUpdated)
    {
        var book = _books.FirstOrDefault(x => x.Id == Id);
        if (book == null)
            return NotFound();

        book.Title = bookUpdated.Title;
        book.Author = bookUpdated.Author;
        book.Genre = bookUpdated.Genre;
        book.Value = bookUpdated.Value;
        book.QuantityInStock = bookUpdated.QuantityInStock;

        return NoContent();
    }

    //DeleteBooks
    [HttpDelete("{Id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult DeleteBook(int Id)
    {
        var book = _books.FirstOrDefault(x => x.Id == Id);
        if (book == null)
            return NotFound();

        _books.Remove(book);
        return NoContent();
    }

}
