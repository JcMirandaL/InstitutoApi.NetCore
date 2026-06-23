using static InstitutoApp.Common.Enums.Enums;

namespace InstitutoApp.DTOs.EstudianteDTOs
{
    public class EstudianteResponseDTO
    {
        public string Cedula { get; set; } = string.Empty;

        public TipoCedula TipoCedula { get; set; }

        public string Nombre { get; set; } = string.Empty;

        public string PrimerApellido { get; set; } = string.Empty;

        public string SegundoApellido { get; set; } = string.Empty;

        public string Correo { get; set; } = string.Empty;

        public string Telefono { get; set; } = string.Empty;

    }
}
