using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Fleet.Web.Controllers;


[ApiController]
[Route("fleet")]
public class FleetController : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<string>> GetAsync()
    {
        await Task.CompletedTask;
        return Ok("Success!!1");
    }
    
    [HttpGet("{id:int}")]
    public async Task<ActionResult<string>> GetByIdAsync(int id)
    {
        if (!ModelState.IsValid)
        {
            return ValidationProblem(ModelState);

        }
        await Task.CompletedTask;
        return Ok("Success!!1");
    }
}