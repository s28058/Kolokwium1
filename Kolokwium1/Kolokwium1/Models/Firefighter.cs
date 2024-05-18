using System.ComponentModel.DataAnnotations;

namespace Kolokwium1.Models;

public class Firefighter
{
    [Required] public int IdFirefight { get; set; }
    [Required][MaxLength(30)] public string FirstName { get; set; }
    [Required][MaxLength(50)] public string LastName { get; set; }
}