using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InstitutoApp.Entities
{
    [Table("tbMatriculas")]
    public class Matricula
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "La cedula es un campo obligatorio.")]
        [StringLength(20, MinimumLength = 8, ErrorMessage = "La cedula debe tener entre 8 y 20 numeros.")]
        public string EstudianteCedula { get; set; } = string.Empty;

        [Required(ErrorMessage = "El Id del curso es un campo obligatorio.")]
        public int CursoId { get; set; }

        public bool Estado { get; set; } = true;
        
        public DateTime FechaMatricula { get; set; } = DateTime.Now;


        //relacion 1 : N (un estudiante muchas matriculas
        //el ! en el null es para indicar que esta propiedad no puede ser null
        public Estudiante Estudiante { get; set; } = null!;

        //relacion 1 : N (un curso muchas matriculas)
        public Curso Curso { get; set; } = null!;

    }
}
