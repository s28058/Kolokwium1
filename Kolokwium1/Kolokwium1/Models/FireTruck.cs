using System.ComponentModel.DataAnnotations;

namespace Kolokwium1.Models;

public class FireTruck
{
    [Required] public int IdFiretruck { get; set; }
    [Required][MaxLength(10)] public string OperationNumber { get; set; }
    [Required] public byte SpecialEquipment { get; set; }
}