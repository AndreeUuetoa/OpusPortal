using App.BLL.Contracts;
using Asp.Versioning;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Public.DTO.Mappers.Library;
using Public.DTO.v1._0.Library;

namespace WebApp.APIControllers.v1._0;

/// <summary>
/// Specify the actions of the MUBA library.
/// For students and teachers - get the books lented out for them.
/// For administrators - lend books out.
/// </summary>
[ApiVersion("1.0")]
[ApiController]
[Route("api/v{version:apiVersion}/[controller]")]
public class BooksLentOutController : ControllerBase
{
    private readonly IAppBLL _bll;
    private readonly BookLentOutMapper _mapper;

    /// <summary>
    /// Create an instance of the BooksLentOutController.
    /// </summary>
    /// <param name="bll"></param>
    /// <param name="autoMapper"></param>
    public BooksLentOutController(IAppBLL bll, IMapper autoMapper)
    {
        _bll = bll;
        _mapper = new BookLentOutMapper(autoMapper);
    }

    // GET: api/BooksLentOut/5
    /// <summary>
    /// Get books lent out by user with the specified ID.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id}")]
    public async Task<ActionResult<IEnumerable<BookLentOut>>> GetBooksLentOut(Guid id)
    {
        var bllBooksLentOutWithUserId = await _bll.BookLentOutService.AllWithUserId(id);

        var res = bllBooksLentOutWithUserId
            .Select(book => _mapper.Map(book))
            .ToList();

        return Ok(res);
    }

    // POST: api/BooksLentOut
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    /// <summary>
    /// Lend out a book.
    /// </summary>
    /// <param name="bookLentOut"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<ActionResult<BookLentOut>> PostBookLentOut(BookLentOut bookLentOut)
    {
        var bllBookLentOut = _mapper.Map(bookLentOut);
        if (bllBookLentOut == null)
        {
            return BadRequest();
        }
        
        var addedBook = await _bll.BookLentOutService.Add(bllBookLentOut);

        if (addedBook == null)
        {
            return BadRequest();
        }

        return CreatedAtAction("GetBooksLentOut", new { id = bookLentOut.Id }, bookLentOut);
    }

    // PUT: api/BooksLentOut/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    /// <summary>
    /// Modify the parameters of the book lent out, e.g. the deadline.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="bookLentOut"></param>
    /// <returns></returns>
    [HttpPut("{id}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> PutBookLentOut(Guid id, BookLentOut bookLentOut)
    {
        if (id != bookLentOut.Id)
        {
            return BadRequest();
        }

        var bllBookLentOut = _mapper.Map(bookLentOut);
        if (bllBookLentOut == null)
        {
            return BadRequest();
        }

        var updatedBookLentOut = await _bll.BookLentOutService.Update(bllBookLentOut);

        if (updatedBookLentOut == null)
        {
            return BadRequest();
        }

        return CreatedAtAction("GetBooksLentOut", new { id }, updatedBookLentOut);
    }

    // DELETE: api/BooksLentOut/5
    /// <summary>
    /// Delete a lent out book - as if the book has been returned to the library.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> DeleteBookLentOut(Guid id)
    {
        var returnedBookLentOut = await _bll.BookLentOutService.Find(id);

        if (returnedBookLentOut == null)
        {
            return BadRequest();
        }

        await _bll.BookLentOutService.RemoveById(id);
        
        return Ok();
    }
}