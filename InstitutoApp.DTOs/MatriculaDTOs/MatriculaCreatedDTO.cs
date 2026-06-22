using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstitutoApp.DTOs.MatriculaDTOs
{
    public class MatriculaCreatedDTO
    {
        [Required(ErrorMessage = "La cedula es un campo obligatorio.")]
        [StringLength(20, MinimumLength = 12, ErrorMessage = "La cedula debe tener entre 12 y 20 numeros.")]
        public string EstudianteCedula { get; set; } = string.Empty;

        [Required(ErrorMessage = "El Id del curso es un campo obligatorio.")]
        public int CursoId { get; set; }
    }
}
