using Kolokwium1.Models;

namespace Kolokwium1.DTOs;

public record FirefighterActionsDTO(Firefighter Firefighter, IEnumerable<FireActionDTO> FireActionDtos);