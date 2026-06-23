using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstitutoApp.DTOs.MatriculaDTOs
{
    public class MatriculaResponseDTO
    {
        public int Id { get; set; }

        public string EstudianteCedula { get; set; } = string.Empty;

        public  string EstudianteNombre { get; set; } = string.Empty;


        public int CursoId { get; set; }

        public string CursoNombre { get; set; } = string.Empty;

        public DateTime FechaMatrucla { get; set; }
    }
}
