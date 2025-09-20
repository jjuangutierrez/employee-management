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
        DeleteAnnouncementUseCase deleteUseCase
        ,
        GetAnnouncementUseCase getUseCase)
    {
        _createUseCase = createUseCase;
        _getAllUseCase = getAllUseCase;
        _updateUseCase = updateUseCase;
        _deleteUseCase = deleteUseCase;
        _getUseCase = getUseCase;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<AnnouncementResponseDto>>> GetAll()
    {
        var result = await _getAllUseCase.ExecuteAsync();
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<AnnouncementResponseDto>> Get(int id)
    {
        var result = await _getUseCase.ExecuteAsync(id);
        if (result == null) return NotFound();
        return Ok(result);
    }


    [HttpPost]
    public async Task<ActionResult<AnnouncementResponseDto>> Create([FromBody] CreateAnnouncementDto dto)
    {
        var result = await _createUseCase.ExecuteAsync(dto);
        return Ok(result);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, [FromBody] UpdateAnnouncementDto dto)
    {
        try
        {
            await _updateUseCase.ExecuteAsync(id, dto);
            return NoContent();
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(new { message = ex.Message });
        }
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            await _deleteUseCase.ExecuteAsync(id);
            return NoContent();
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(new { message = ex.Message });
        }
    }
}
