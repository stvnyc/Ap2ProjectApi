using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ap2ProjectApi.Data.models;

public class Prioridades
{
    [Key]
    public int PrioridadId { get; set; }
    [Required(ErrorMessage = "Este campo es obligatorio")]
    public string? Descripcion { get; set; }
    [Required(ErrorMessage = "Este campo es obligatorio")]
    public int DiasCompromiso { get; set; }
}