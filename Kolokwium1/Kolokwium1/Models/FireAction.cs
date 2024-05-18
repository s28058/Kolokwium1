using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace Kolokwium1.Models;

public class FireAction
{
    [Required] public int IdFireAction { get; set; }
    [Required] public DateTime StartTime { get; set; }
    public DateTime? EndTime { get; set; }
    [Required] public byte NeedSpecialEquipment { get; set; }
}