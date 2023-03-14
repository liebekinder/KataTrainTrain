using Fleet.Infra.Repositories;
using Fleet.Web.Mappers;
using Fleet.Web.Payloads;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Shared.Web.Extensions;
using System.Threading.Tasks;

namespace Fleet.Web.Controllers;

[ApiController]
[Route("locomotives")]
public class LocomotiveController : ControllerBase
{
    private readonly LocomotiveRepository _locomotiveRepository;
    private IValidator<LocomotivePayload> _payloadValidator;

    public LocomotiveController(LocomotiveRepository locomotiveRepository, IValidator<LocomotivePayload> payloadValidator)
    {
        _locomotiveRepository = locomotiveRepository;
        _payloadValidator = payloadValidator;
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


    [HttpPost]
    public async Task<IActionResult> CreateAsync(LocomotivePayload payload)
    {
        var payloadValidator = await _payloadValidator.ValidateAsync(payload);
        if (!payloadValidator.IsValid)
        {
            return this.ValidationProblem(payloadValidator);
        }

        var locomotive = LocomotiveMapper.MapToDbModel(payload);

        var locomotiveResult = await _locomotiveRepository.CreateAsync(locomotive);

        return Ok(LocomotiveMapper.MapToViewModel(locomotiveResult));
    }

    [HttpDelete]
    [Route("{id:int}")]
    public async Task<IActionResult> DeleteByIdAsync(int id)
    {
        await _locomotiveRepository.DeleteByIdAsync(id);

        return NoContent();
    }
}

