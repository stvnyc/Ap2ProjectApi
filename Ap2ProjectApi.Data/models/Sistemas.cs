using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ap2ProjectApi.Data.models;

public class Sistemas
{
    [Key]
    [Required(ErrorMessage = "El campo es obligatorio")]
    public int SistemaId { get; set; }
    [Required(ErrorMessage = "El campo es obligatorio")]
    [RegularExpression(@"^[A-Za-z0-9\s]*$", ErrorMessage = "El nombre del sistema solo puede contener letras, números y espacios")]
    public string? SistemaNombre { get; set; }
}
