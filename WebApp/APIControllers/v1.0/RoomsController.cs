using App.BLL.Contracts;
using Asp.Versioning;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Public.DTO.Mappers.Rooms;
using Public.DTO.v1._0.Rooms;

namespace WebApp.APIControllers.v1._0;

/// <summary>
/// Add, edit and remove rooms Muba students could reserve and practice in.
/// </summary>
[ApiController]
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/[controller]")]
public class RoomsController : ControllerBase
{
    private readonly IAppBLL _bll;
    private readonly RoomMapper _mapper;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="bll"></param>
    /// <param name="autoMapper"></param>
    public RoomsController(IAppBLL bll, IMapper autoMapper)
    {
        _bll = bll;
        _mapper = new RoomMapper(autoMapper);
    }

    // GET: api/Rooms
    /// <summary>
    /// Get all rooms users may reserve for practicing or studying.
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Room>>> GetRooms()
    {
        var rooms = await _bll.RoomService.All();

        var res = rooms
            .Select(r => _mapper.Map(r))
            .ToList();

        return Ok(res);
    }

    // GET: api/Rooms/5
    /// <summary>
    /// Get details about a room with the specified ID.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id}")]
    public async Task<ActionResult<Room>> GetRoom(Guid id)
    {
        var room = await _bll.RoomService.Find(id);

        if (room == null)
        {
            return NotFound();
        }

        var res = _mapper.Map(room);

        if (res == null)
        {
            return BadRequest();
        }

        return Ok(res);
    }

    // PUT: api/Rooms/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    /// <summary>
    /// Edit a room.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="room"></param>
    /// <returns></returns>
    [HttpPut("{id}")]
    public async Task<IActionResult> PutRoom(Guid id, Room room)
    {
        if (id != room.Id)
        {
            return BadRequest();
        }

        var bllRoom = _mapper.Map(room);

        if (bllRoom == null)
        {
            return BadRequest();
        }
        var updatedRoom = await _bll.RoomService.Update(bllRoom);

        if (updatedRoom == null)
        {
            return BadRequest();
        }

        return CreatedAtAction(nameof(GetRooms), new
        {
            Version = HttpContext.GetRequestedApiVersion()?.ToString(),
            id = room.Id
        }, room);
    }

    // POST: api/Rooms
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    /// <summary>
    /// Add a room.
    /// </summary>
    /// <param name="room"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<ActionResult<Room>> PostRoom(Room room)
    {
        var bllRoom = _mapper.Map(room);
        if (bllRoom == null)
        {
            return BadRequest();
        }

        var addedRoom = await _bll.RoomService.Add(bllRoom);
        if (addedRoom == null)
        {
            return BadRequest();
        }

        return CreatedAtAction(nameof(GetRoom), new {
            Version = HttpContext.GetRequestedApiVersion()?.ToString(),
            id = room.Id
        }, addedRoom);
    }

    // DELETE: api/Rooms/5
    /// <summary>
    /// Remove a room.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteRoom(Guid id)
    {
        var removedRoom = await _bll.RoomService.RemoveById(id);

        if (removedRoom == null)
        {
            return BadRequest();
        }

        return Ok();
    }
}