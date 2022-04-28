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
}