using App.BLL.Contracts;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Public.DTO.Mappers.Concerts;
using Public.DTO.v1._0.Concerts;

namespace WebApp.APIControllers.v1._0;

/// <summary>
/// 
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class AppUserAtConcertsController : ControllerBase
{
    private readonly IAppBLL _bll;
    private readonly AppUserAtConcertMapper _mapper;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="bll"></param>
    /// <param name="autoMapper"></param>
    public AppUserAtConcertsController(IAppBLL bll, IMapper autoMapper)
    {
        _bll = bll;
        _mapper = new AppUserAtConcertMapper(autoMapper);
    }

    // GET: api/Performance/5
    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id}")]
    public async Task<ActionResult<Domain.Concerts.AppUserAtConcert>> GetAppUsersAtConcert(Guid id)
    {
        var appUserAtConcert = await _bll.AppUserAtConcertService.Find(id);

        if (appUserAtConcert == null)
        {
            return NotFound();
        }

        var res = _mapper.Map(appUserAtConcert);

        return Ok(res);
    }

    // POST: api/Performance
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    /// <summary>
    /// 
    /// </summary>
    /// <param name="appUserAtConcert"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<ActionResult<Domain.Concerts.AppUserAtConcert>> PostAppUserAtConcert(AppUserAtConcert appUserAtConcert)
    {
        var bllAppUserAtConcert = _mapper.Map(appUserAtConcert);
        if (bllAppUserAtConcert == null)
        {
            return BadRequest();
        }

        var addedAppUserAtConcert = await _bll.AppUserAtConcertService.Add(bllAppUserAtConcert);

        if (addedAppUserAtConcert == null)
        {
            return BadRequest();
        }

        return CreatedAtAction("GetAppUsersAtConcert", new { id = appUserAtConcert.Id }, appUserAtConcert);
    }

    // PUT: api/Performance/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <param name="appUserAtConcert"></param>
    /// <returns></returns>
    [HttpPut("{id}")]
    public async Task<IActionResult> PutAppUserAtConcert(Guid id, AppUserAtConcert appUserAtConcert)
    {
        if (id != appUserAtConcert.Id)
        {
            return BadRequest();
        }

        var bllAppUserAtConcert = _mapper.Map(appUserAtConcert);
        if (bllAppUserAtConcert == null)
        {
            return BadRequest();
        }

        var updatedAppUserAtConcert = await _bll.AppUserAtConcertService.Update(bllAppUserAtConcert);

        if (updatedAppUserAtConcert == null)
        {
            return BadRequest();
        }

        return NoContent();
    }

    // DELETE: api/Performance/5
    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAppUserAtConcert(Guid id)
    {
        var appUserAtConcertToDelete = await _bll.AppUserAtConcertService.Find(id);

        if (appUserAtConcertToDelete == null)
        {
            return BadRequest();
        }

        await _bll.AppUserAtConcertService.RemoveById(id);
        
        return Ok();
    }
}