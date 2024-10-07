using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ap2ProjectApi.Data.models;

public class Clientes
{
    [Key]
    public int ClienteId { get; set; }
    [StringLength(30, ErrorMessage = "No Puede Exceder los 30 Caracteres")]
    [Required(ErrorMessage = "El campo Nombre es requerido")]
    public string? Nombre { get; set; }
    [Required(ErrorMessage = "El campo Telefono es requerido")]
    public string? Telefono { get; set; }
    [Required(ErrorMessage = "El campo Celular es requerido")]
    public string? Celular { get; set; }
    [Required(ErrorMessage = "El campo Rnc es requerido")]
    public string? Rnc { get; set; }
    [Required(ErrorMessage = "El campo Email es requerido")]
    public string? Email { get; set; }
    [StringLength(60, ErrorMessage = "No Puede Exceder los 60 Caracteres")]
    [Required(ErrorMessage = "El campo Direccion es requerido")]
    public string? Direccion { get; set; }
}
