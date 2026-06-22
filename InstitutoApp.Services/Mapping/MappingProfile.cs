using AutoMapper;
using InstitutoApp.Entities;
using InstitutoApp.DTOs.CursoDTOs;
using InstitutoApp.DTOs.EstudianteDTOs;
using InstitutoApp.DTOs.MatriculaDTOs;


namespace InstitutoApp.Services.Mapping
{
    public class MappingProfile : Profile
    {
    
        public MappingProfile() 
        {
            //De DTOCreated a ENTIDAD
            CreateMap<CursoCreatedDTO, Curso>();
            CreateMap<EstudianteCreatedDTO, Estudiante>();
            CreateMap<MatriculaCreatedDTO, Matricula>();

            //De DTOUpdate a ENTIDAD
            CreateMap<CursoUpdateDTO, Curso>();
            CreateMap<EstudianteUpdateDTO, Estudiante>();

            //De ENTIDAD a DTO
            CreateMap<Curso, CursoResponseDTO>();
            CreateMap<Estudiante, EstudianteResponseDTO>();
            CreateMap<Matricula, MatriculaResponseDTO>();
        }
    }
}
