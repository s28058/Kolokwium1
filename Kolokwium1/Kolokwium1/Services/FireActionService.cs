using Kolokwium1.DTOs;
using Kolokwium1.Models;
using Kolokwium1.Repositories;
using Kolokwium1.Exceptions;

namespace Kolokwium1.Services;

public class FireActionService : IFireActionService
{
    private readonly IFireActionRepo _fireActionRepo;

    public FireActionService(IFireActionRepo fireActionRepo)
    {
        _fireActionRepo = fireActionRepo;
    }


    public async Task<FirefighterActionsDTO> GetFirefighterWithActions(int id)
    {
        Firefighter? firefighter = await _fireActionRepo.GetFirefighterByIdAsync(id);
        if (firefighter == null)
        {
            throw new NoFirefighterExeption();
        }
        
        IEnumerable<FireActionDTO> actionsList = await _fireActionRepo.GetActionsForFirefighter(id);

        FirefighterActionsDTO firefighterActionsDto = new FirefighterActionsDTO(firefighter, actionsList);
        return firefighterActionsDto;
    }

}