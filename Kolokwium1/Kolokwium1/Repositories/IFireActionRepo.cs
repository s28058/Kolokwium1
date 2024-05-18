using Kolokwium1.DTOs;
using Kolokwium1.Models;

namespace Kolokwium1.Repositories;

public interface IFireActionRepo
{
    Task<Firefighter> GetFirefighterByIdAsync(int id);
    Task<IEnumerable<FireActionDTO>> GetActionsForFirefighter(int id);
    Task<FireAction> GetFireActionByIdAsync(int id);

}