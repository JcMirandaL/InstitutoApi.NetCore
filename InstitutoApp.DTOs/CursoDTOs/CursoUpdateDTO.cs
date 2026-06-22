using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstitutoApp.DTOs.CursoDTOs
{
    public class CursoUpdateDTO
    {
        [Required(ErrorMessage = "El Id es un campo obligatorio.")]
        [Range(1, int.MaxValue, ErrorMessage = "El Id debe ser un número positivo.")]
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es un campo obligatorio.")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "El nombre debe de tener entre 3 y 100 caracteres.")]
        public string Nombre { get; set; } = string.Empty;

        [StringLength(500, ErrorMessage = "La descripción no puede exceder los 500 caracteres.")]
        public string? Descripcion { get; set; } = string.Empty;

        [Range(1, int.MaxValue, ErrorMessage = "El cupo máximo debe ser un número positivo.")]
        public int CupoMaximo { get; set; }
    }
}
