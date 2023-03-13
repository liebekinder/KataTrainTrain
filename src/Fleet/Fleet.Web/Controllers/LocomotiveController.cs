using Fleet.Infra.Repositories;
using Fleet.Web.Mappers;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Fleet.Web.Controllers;

[ApiController]
[Route("locomotives")]
public class LocomotiveController : ControllerBase
{
    private readonly LocomotiveRepository _locomotiveRepository;

    public LocomotiveController(LocomotiveRepository locomotiveRepository)
    {
        _locomotiveRepository = locomotiveRepository;
    }

    [HttpGet]
    public async Task<IActionResult> GetAsync()
    {
        var locomotives = await _locomotiveRepository.GetAllAsync();

        return Ok(LocomotiveMapper.MapToViewModel(locomotives));
    }

    [HttpGet]
    [Route("{id:int}")]
    public async Task<IActionResult> GetByIdAsync(int id)
    {
        var locomotive = await _locomotiveRepository.GetByIdAsync(id);

        if (locomotive is null)
        {
            return NotFound();
        }

        return Ok(LocomotiveMapper.MapToViewModel(locomotive));
    }

    [HttpDelete]
    [Route("{id:int}")]
    public async Task<IActionResult> DeleteByIdAsync(int id)
    {
        await _locomotiveRepository.DeleteByIdAsync(id);

        return NoContent();
    }
}

