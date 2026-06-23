using AutoMapper;
using InstitutoApp.Common.Exceptions;
using InstitutoApp.Common.Interfaces;
using InstitutoApp.Common.Response;
using InstitutoApp.DTOs.MatriculaDTOs;
using InstitutoApp.Entities;
using InstitutoApp.Repository;

namespace InstitutoApp.Services
{
    public class MatriculaService : IGenericService<MatriculaResponseDTO, MatriculaCreatedDTO, MatriculaUpdateDTO>
    {
        private readonly MatriculaRepository _matriculaRepository;
        private readonly CursoRepository _cursoRepository;
        private readonly EstdianteRepository _estudianteRepository;
        private readonly IMapper _mapper;


        public MatriculaService(
            MatriculaRepository matriculaRepository,
            CursoRepository cursoRepository,
            EstdianteRepository estudianteRepository,
            IMapper mapper
            )
        {
            _matriculaRepository = matriculaRepository;
            _cursoRepository = cursoRepository;
            _estudianteRepository = estudianteRepository;
            _mapper = mapper;
        }





        public async Task<Response<List<MatriculaResponseDTO>>> GetAllAsync()
        {
            var matriculaList = await _matriculaRepository.GetAllAsync();
            if (matriculaList == null || matriculaList.Count == 0)
            {
                throw new NotFoundDbException("No se encontraron matriculas.");
            }

            return new Response<List<MatriculaResponseDTO>>
            {
                Message = "Matriculas obtenidas exitosamente: ",
                Data = _mapper.Map<List<MatriculaResponseDTO>>(matriculaList),
                Success = true
            };
        }


        public async Task<Response<MatriculaResponseDTO>> GetByIdAsync(int id)
        {
            var matricula = await _matriculaRepository.GetByIdAsync(id);
            if (matricula == null)
            {
                throw new NotFoundDbException($"No se encontró la matricula con ID {id}.");
            }

            return new Response<MatriculaResponseDTO>
            {
                Message = "Matricula obtenida exitosamente: ",
                Data = _mapper.Map<MatriculaResponseDTO>(matricula),
                Success = true
            };
        }


        public async Task<Response<MatriculaResponseDTO>> CreateAsync(MatriculaCreatedDTO entity)
        {
            var studentExists = await _estudianteRepository.GetByIdAsync(entity.EstudianteCedula);
            if (studentExists == null)
            {
                throw new NotFoundDbException($"No se encontró el estudiante con cédula {entity.EstudianteCedula}.");
            }

            var courseExists = await _cursoRepository.GetByIdAsync(entity.CursoId);
            if (courseExists == null)
            {
                throw new NotFoundDbException($"No se encontró el curso con ID {entity.CursoId}.");
            }

            if (courseExists.Matriculas.Any(m => m.EstudianteCedula == entity.EstudianteCedula))
            {
                throw new EntityExistDbException($"El estudiante con cédula {entity.EstudianteCedula} ya está matriculado en el curso con ID {entity.CursoId}.");
            }

            if (courseExists.Matriculas.Count >= courseExists.CupoMaximo)
            {
                throw new MaximumCapacityDbException($"El curso con ID {entity.CursoId} ha alcanzado su cupo máximo.");
            }

            Matricula newMatricula = _mapper.Map<Matricula>(entity);

            newMatricula = await _matriculaRepository.CreateAsync(newMatricula);

            //actualizo newMatricula con los datos completos del estudiante y curso
            //para q el rsponse tenga toda la info necesaria
            newMatricula.Estudiante = studentExists;
            newMatricula.Curso = courseExists;

            return new Response<MatriculaResponseDTO>
            {
                Message = "Matricula creada exitosamente: ",
                Data = _mapper.Map<MatriculaResponseDTO>(newMatricula),
                Success = true
            };
        }


        public Task<Response<bool>> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }


        public Task<Response<MatriculaResponseDTO>> UpdateAsync(MatriculaUpdateDTO entity)
        {
            throw new NotImplementedException();
        }
    
    }
}
