using App.BLL.Contracts;
using Asp.Versioning;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Public.DTO.Mappers.Concerts;
using Public.DTO.v1._0.Concerts;

namespace WebApp.APIControllers.v1._0;

/// <summary>
/// Add, edit and remove concerts that the MUBA students may participate in.
/// </summary>
[ApiVersion("1.0")]
[ApiController]
[Route("api/v{version:apiVersion}/[controller]")]
[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
public class ConcertsController : ControllerBase
{
    private readonly IAppBLL _bll;
    private readonly ConcertMapper _mapper;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="bll"></param>
    /// <param name="autoMapper"></param>
    public ConcertsController(IAppBLL bll, IMapper autoMapper)
    {
        _bll = bll;
        _mapper = new ConcertMapper(autoMapper);
    }

    // GET: api/Concerts
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Concert>>> GetConcerts()
    {
        var concerts = await _bll.ConcertService.All();

        var res = concerts
            .Select(c => _mapper.Map(c))
            .ToList();

        return Ok(res);
    }

    // GET: api/Concerts/5
    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id}")]
    public async Task<ActionResult<Concert>> GetConcert(Guid id)
    {
        var concert = await _bll.ConcertService.Find(id);

        if (concert == null)
        {
            return NotFound();
        }

        var res = _mapper.Map(concert);

        if (res == null)
        {
            return NotFound();
        }

        return Ok(res);
    }

    // PUT: api/Concerts/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <param name="concert"></param>
    /// <returns></returns>
    [HttpPut("{id}")]
    public async Task<IActionResult> PutConcert(Guid id, Concert concert)
    {
        if (id != concert.Id)
        {
            return BadRequest();
        }

        var bllConcert = _mapper.Map(concert);

        if (bllConcert == null)
        {
            return BadRequest();
        }
        var updatedConcert = await _bll.ConcertService.Update(bllConcert);

        if (updatedConcert == null)
        {
            return BadRequest();
        }

        return CreatedAtAction(nameof(GetConcerts), new
        {
            Version = HttpContext.GetRequestedApiVersion()?.ToString(),
            id = concert.Id
        }, concert);
    }

    // POST: api/Concerts
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    /// <summary>
    /// 
    /// </summary>
    /// <param name="concert"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<ActionResult<Concert>> PostConcert(Concert concert)
    {
        var bllConcert = _mapper.Map(concert);
        if (bllConcert == null)
        {
            return NotFound();
        }
        var addedConcert = await _bll.ConcertService.Add(bllConcert);

        if (addedConcert == null)
        {
            return BadRequest();
        }

        return CreatedAtAction(nameof(GetConcerts), new {
            Version = HttpContext.GetRequestedApiVersion()?.ToString(),
            id = concert.Id
        }, addedConcert);
    }

    // DELETE: api/Concerts/5
    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteConcert(Guid id)
    {
        var removedConcert = await _bll.ConcertService.RemoveById(id);

        if (removedConcert == null)
        {
            return BadRequest();
        }

        return Ok();
    }
}