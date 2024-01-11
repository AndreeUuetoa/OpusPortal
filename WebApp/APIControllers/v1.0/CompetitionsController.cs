using App.BLL.Contracts;
using App.DAL.Contracts;
using Asp.Versioning;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Public.DTO.Mappers.Competitions;
using Public.DTO.v1._0.Competitions;

namespace WebApp.APIControllers.v1._0;

/// <summary>
/// Configure the competitions that the students of MUBA can take part in.
/// </summary>
[ApiVersion("1.0")]
[ApiController]
[Route("api/v{version:apiVersion}/[controller]")]
[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
public class CompetitionsController : ControllerBase
{
    private readonly IAppBLL _bll;
    private readonly CompetitionMapper _mapper;

    /// <summary>
    /// Constructor for competitions controller.
    /// </summary>
    /// <param name="bll"></param>
    /// <param name="autoMapper"></param>
    public CompetitionsController(IAppBLL bll, IMapper autoMapper)
    {
        _bll = bll;
        _mapper = new CompetitionMapper(autoMapper);
    }

    // GET: api/Competitions
    /// <summary>
    /// Get all competitions users may participate in.
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Competition>>> GetCompetitions()
    {
        var competitions = await _bll.CompetitionService.All();

        var res = competitions
            .Select(c => _mapper.Map(c))
            .ToList();

        return Ok(res);
    }

    // GET: api/Competitions/5
    /// <summary>
    /// Get details about a competition with the specified ID.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id}")]
    public async Task<ActionResult<Competition>> GetCompetition(Guid id)
    {
        var competition = await _bll.CompetitionService.Find(id);

        if (competition == null)
        {
            return NotFound();
        }

        var res = _mapper.Map(competition);

        if (res == null)
        {
            return NotFound();
        }

        return Ok(res);
    }

    // PUT: api/Competitions/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    /// <summary>
    /// Edit a competition.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="competition"></param>
    /// <returns></returns>
    [HttpPut("{id}")]
    public async Task<IActionResult> PutCompetition(Guid id, Competition competition)
    {
        var competitionWithId = await _bll.CompetitionService.Find(id);
        if (competitionWithId == null || competition.Name != competitionWithId.Name)
        {
            return BadRequest();
        }

        var bllCompetition = _mapper.Map(competition);
        if (bllCompetition == null)
        {
            return BadRequest();
        }

        var updatedCompetition = await _bll.CompetitionService.UpdateById(id);

        if (updatedCompetition == null)
        {
            return BadRequest();
        }

        return CreatedAtAction(nameof(GetCompetitions), new
        {
            Version = HttpContext.GetRequestedApiVersion()?.ToString(),
            id = competition.Id
        }, competition);
    }

    // POST: api/Competitions
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    /// <summary>
    /// Add a competition.
    /// </summary>
    /// <param name="competition"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<ActionResult<Competition>> PostCompetition(Competition competition)
    {
        var bllCompetition = _mapper.Map(competition);
        if (bllCompetition == null)
        {
            return BadRequest();
        }
        
        var addedCompetition = await _bll.CompetitionService.Add(bllCompetition);

        if (addedCompetition == null)
        {
            return BadRequest();
        }

        return CreatedAtAction(nameof(GetCompetitions), new {
            Version = HttpContext.GetRequestedApiVersion()?.ToString(),
            id = competition.Id
        }, addedCompetition);
    }

    // DELETE: api/Competitions/5
    /// <summary>
    /// Remove a competition.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCompetition(Guid id)
    {
        var removedCompetition = await _bll.CompetitionService.RemoveById(id);

        if (removedCompetition == null)
        {
            return BadRequest();
        }

        return Ok();
    }
}