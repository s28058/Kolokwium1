using Kolokwium1.DTOs;
using Kolokwium1.Exceptions;
using Kolokwium1.Services;
using Microsoft.AspNetCore.Mvc;

namespace Kolokwium1.Controllers;

[Route("api/[controller]")]
[ApiController]
public class FireActionController : ControllerBase
{
    private readonly IFireActionService _fireActionService;

    public FireActionController(IFireActionService fireActionService)
    {
        _fireActionService = fireActionService;
    }
    
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetInfoAboutTeamOnChampionship(int id)
    {
        FirefighterActionsDTO action;
        try
        {
            action = await _fireActionService.GetFirefighterWithActions(id);
        }catch(NoFirefighterExeption){
            return StatusCode(404, "No such firefighter");
        }

        return Ok(action);
    }
}