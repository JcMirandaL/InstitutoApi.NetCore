using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static InstitutoApp.Common.Enums.Enums;

namespace InstitutoApp.Entities
{
    [Table("tbEstudiantes")]
    public class Estudiante
    {
        [Key]
        [Required(ErrorMessage = "La cedula es un campo obligatorio.")]
        [StringLength(20, MinimumLength = 12, ErrorMessage = "La cedula debe tener entre 12 y 20 numeros.")]
        public string Cedula { get; set; } = string.Empty;

        [Required(ErrorMessage = "El tipo de cedula es un campo obligatorio.")]
        [EnumDataType(typeof(TipoCedula), ErrorMessage = "El tipo de cedula solo puede ser 1, 2, 3, 4, 5")]
        public TipoCedula TipoCedula { get; set; } = TipoCedula.Nacional;

        [Required(ErrorMessage = "El nombre es un campo obligatorio.")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "El nombre debe de tener entre 3 y 100 caracteres.")]
        public string Nombre { get; set; } = string.Empty;

        [Required(ErrorMessage = "El primer apellido es un campo obligatorio.")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "El primer apellido debe de tener entre 3 y 100 caracteres.")]
        public string PrimerApellido { get; set; } = string.Empty;

        [Required(ErrorMessage = "El segundo apellido es un campo obligatorio.")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "El segundo apellido debe de tener entre 3 y 100 caracteres.")]
        public string SegundoApellido { get; set; } = string.Empty;

        [Required(ErrorMessage = "El correo electrónico es un campo obligatorio.")]
        [EmailAddress(ErrorMessage = "El correo electrónico debe tener un formato valido.")]
        [StringLength(150, MinimumLength = 3, ErrorMessage = "El correo electronico debe de tener entre 3 y 150 caracteres.")]
        public string Correo { get; set; } = string.Empty;

        [Required(ErrorMessage = "El número de teléfono es un campo obligatorio.")]
        [Phone(ErrorMessage = "El número de teléfono debe tener un formato válido.")]
        [MaxLength(20, ErrorMessage = "El número de teléfono no puede tener más de 20 caracteres.")]
        public string Telefono { get; set; } = string.Empty;

        public bool Estado { get; set; } = true;

        public DateTime FechaCreacion { get; set; } = DateTime.Now;



        //relacion con matricula
        public ICollection<Matricula> Matriculas { get; set; } = new List<Matricula>();
    }
}
