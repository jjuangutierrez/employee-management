using EmployeeManagement.Application.DTOs.Announcement;
using EmployeeManagement.Application.UseCases.Announcement;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AnnouncementsController : ControllerBase
{
    private readonly CreateAnnouncementUseCase _createUseCase;
    private readonly GetAllAnnouncementsUseCase _getAllUseCase;
    private readonly UpdateAnnouncementUseCase _updateUseCase;
    private readonly DeleteAnnouncementUseCase _deleteUseCase;
    private readonly GetAnnouncementUseCase _getUseCase;

    public AnnouncementsController(
        CreateAnnouncementUseCase createUseCase,
        GetAllAnnouncementsUseCase getAllUseCase,
        UpdateAnnouncementUseCase updateUseCase,
        DeleteAnnouncementUseCase deleteUseCase,
        GetAnnouncementUseCase getUseCase)
    {
        _createUseCase = createUseCase ?? throw new ArgumentNullException(nameof(createUseCase));
        _getAllUseCase = getAllUseCase ?? throw new ArgumentNullException(nameof(getAllUseCase));
        _updateUseCase = updateUseCase ?? throw new ArgumentNullException(nameof(updateUseCase));
        _deleteUseCase = deleteUseCase ?? throw new ArgumentNullException(nameof(deleteUseCase));
        _getUseCase = getUseCase ?? throw new ArgumentNullException(nameof(getUseCase));
    }

    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<AnnouncementResponseDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<AnnouncementResponseDto>>> GetAllAnnouncements()
    {
        try
        {
            var result = await _getAllUseCase.ExecuteAsync();
            return Ok(result);
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while retrieving announcements");
        }
    }

    [HttpGet("{id}")]
    [ProducesResponseType(typeof(AnnouncementResponseDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<AnnouncementResponseDto>> GetAnnouncement(int id)
    {
        try
        {
            var result = await _getUseCase.ExecuteAsync(id);
            return Ok(result);
        }
        catch (KeyNotFoundException)
        {
            return NotFound($"Announcement with ID {id} not found");
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost]
    [ProducesResponseType(typeof(AnnouncementResponseDto), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<AnnouncementResponseDto>> CreateAnnouncement([FromBody] CreateAnnouncementDto createAnnouncementDto)
    {
        try
        {
            var result = await _createUseCase.ExecuteAsync(createAnnouncementDto);
            return CreatedAtAction(nameof(GetAnnouncement), new { id = result.Id }, result);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPatch("{id}")]
    [ProducesResponseType(typeof(AnnouncementResponseDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<AnnouncementResponseDto>> UpdateAnnouncement(int id, [FromBody] UpdateAnnouncementDto updateAnnouncementDto)
    {
        try
        {
            var result = await _updateUseCase.ExecuteAsync(id, updateAnnouncementDto);
            return Ok(result);
        }
        catch (KeyNotFoundException)
        {
            return NotFound($"Announcement with ID {id} not found");
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(typeof(AnnouncementResponseDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<AnnouncementResponseDto>> DeleteAnnouncement(int id)
    {
        try
        {
            var result = await _deleteUseCase.ExecuteAsync(id);
            return Ok(result);
        }
        catch (KeyNotFoundException)
        {
            return NotFound($"Announcement with ID {id} not found");
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
    }
}