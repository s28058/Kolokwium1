using Kolokwium1.DTOs;

namespace Kolokwium1.Services;

public interface IFireActionService
{
    Task<FirefighterActionsDTO> GetFirefighterWithActions(int id);
}