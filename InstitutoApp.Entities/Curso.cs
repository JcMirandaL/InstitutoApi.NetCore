

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InstitutoApp.Entities
{
    [Table("tbCursos")]
    public class Curso
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es un campo obligatorio.")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "El nombre debe de tener entre 3 y 100 caracteres.")]
        public string Nombre { get; set; } = string.Empty;

        [StringLength(500, ErrorMessage = "La descripción no puede exceder los 500 caracteres.")]
        public string? Descripcion { get; set; } = string.Empty;

        [Range(1, int.MaxValue, ErrorMessage = "El cupo máximo debe ser un número positivo.")]
        public int CupoMaximo { get; set; }

        public bool Estado { get; set; } = true;

        public DateTime FechaCreacion { get; set; } = DateTime.Now;



        //relacion con matricula
        public ICollection<Matricula> Matriculas { get; set; } = new List<Matricula>();

    }
}
