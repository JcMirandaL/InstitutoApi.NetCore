using AutoMapper;
using InstitutoApp.Common.Interfaces;
using InstitutoApp.Common.Response;
using InstitutoApp.DTOs.EstudianteDTOs;
using InstitutoApp.Repository;
using InstitutoApp.Common.Exceptions;
using InstitutoApp.Entities;

namespace InstitutoApp.Services
{
    public class EstdianteService : IEstdianteService<EstudianteResponseDTO, EstudianteCreatedDTO, EstudianteUpdateDTO>
    {
        //injeccion dependencia hacia el repositorio
        private readonly EstdianteRepository _estudianteRepository;
        private readonly IMapper _mapper;

        public EstdianteService(EstdianteRepository estudianteRepository, IMapper mapper)
        {
            _estudianteRepository = estudianteRepository;
            _mapper = mapper;
        }




        public async Task<Response<List<EstudianteResponseDTO>>> GetAllAsync()
        {
            var listStudents = await _estudianteRepository.GetAllAsync();
            if (listStudents == null || listStudents.Count == 0)
            {
                throw new NotFoundDbException("No se encontraron estudiantes en la base de datos.");
            }

            return new Response<List<EstudianteResponseDTO>>
            {
                Message = "Lista de estudiantes obtenida exitosamente: ",
                Data = _mapper.Map<List<EstudianteResponseDTO>>(listStudents),
                Success = true
            };

        }
        

        public async Task<Response<EstudianteResponseDTO>> GetByIdAsync(string cedula)
        {
            var student = await _estudianteRepository.GetByIdAsync(cedula);
            if (student == null)
            {
                throw new NotFoundDbException($"No se encontró un estudiante con la cedula {cedula}.");
            }

            return new Response<EstudianteResponseDTO>
            {
                Message = "Estudiante obtenido exitosamente: ",
                Data = _mapper.Map<EstudianteResponseDTO>(student),
                Success = true
            };
        }


        public async Task<Response<EstudianteResponseDTO>> CreateAsync(EstudianteCreatedDTO entity)
        {
            var studentExists = await _estudianteRepository.GetByIdAsync(entity.Cedula);
            if (studentExists != null)
            {
                throw new EntityExistDbException($"Ya existe un estudiante con la cedula {entity.Cedula}.");
            }

            var emailExists = await _estudianteRepository.GetByEmailAsync(entity.Correo);
            if (emailExists != null)
            {
                throw new EntityExistDbException($"Ya existe un estudiante con el correo {entity.Correo}.");
            }

            Estudiante newStudent = _mapper.Map<Estudiante>(entity);

            newStudent = await _estudianteRepository.CreateAsync(newStudent);

            return new Response<EstudianteResponseDTO>
            {
                Message = "Estudiante creado exitosamente: ",
                Data = _mapper.Map<EstudianteResponseDTO>(newStudent),
                Success = true
            };

        }


        public async Task<Response<EstudianteResponseDTO>> UpdateAsync(EstudianteUpdateDTO entity)
        {
            var studentExists = await _estudianteRepository.GetByIdAsync(entity.Cedula);
            if (studentExists == null)
            {
                throw new NotFoundDbException($"No existe un estudiante con la cedula {entity.Cedula}.");
            }
            if (studentExists != null && studentExists.Cedula != entity.Cedula)
            {
                throw new EntityExistDbException($"Ya existe un estudiante con la cedula {entity.Cedula}.");
            }

            var emailExists = await _estudianteRepository.GetByEmailAsync(entity.Correo);
            if (emailExists != null && emailExists.Correo != entity.Correo)
            {
                throw new EntityExistDbException($"Ya existe un estudiante con el correo {entity.Correo}.");
            }

            Estudiante updatedStudent = _mapper.Map<Estudiante>(entity);

            updatedStudent = await _estudianteRepository.UpdateAsync(updatedStudent);

            return new Response<EstudianteResponseDTO>
            {
                Message = "Estudiante actualizado exitosamente: ",
                Data = _mapper.Map<EstudianteResponseDTO>(updatedStudent),
                Success = true
            };
        }


        public async Task<Response<bool>> DeleteAsync(string cedula)
        {
            var studentExists = await _estudianteRepository.GetByIdAsync(cedula);
            if (studentExists == null)
            {
                throw new NotFoundDbException($"No se encontró un estudiante con la cedula {cedula}.");
            }

            studentExists.Estado = false;

            await _estudianteRepository.UpdateAsync(studentExists);

            return new Response<bool>
            {
                Message = "Estudiante eliminado exitosamente: ",
                Data = true,
                Success = true
            };
        }


      
    }
}
