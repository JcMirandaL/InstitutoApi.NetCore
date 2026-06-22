using AutoMapper;
using InstitutoApp.Common.Interfaces;
using InstitutoApp.Common.Response;
using InstitutoApp.DTOs.CursoDTOs;
using InstitutoApp.Repository;
using InstitutoApp.Common.Exceptions;
using InstitutoApp.Entities;


namespace InstitutoApp.Services
{
    public class CursoService : IGenericService<CursoResponseDTO, CursoCreatedDTO, CursoUpdateDTO>
    {
        //injeccion dependencia hacia el repo
        private readonly CursoRepository _cursoRepository;
        private readonly IMapper _mapper;


        public CursoService(CursoRepository cursoRepository, IMapper mapper)
        {
            _cursoRepository = cursoRepository;
            _mapper = mapper;
        }






        public async Task<Response<List<CursoResponseDTO>>> GetAllAsync()
        {
            var productList = await _cursoRepository.GetAllAsync();
            if (productList == null || productList.Count == 0)
            {
               throw new NotFoundDbException("No se encontraron cursos en la base de datos.");
            }

            return new Response<List<CursoResponseDTO>>
            {
                Message = "Cursos obtenidos exitosamente: ",
                Data = _mapper.Map<List<CursoResponseDTO>>(productList),
                Success = true
            };
        }

        
        public async Task<Response<CursoResponseDTO>> GetByIdAsync(int id)
        {
            var curso = await _cursoRepository.GetByIdAsync(id);
            if (curso == null)
            {
                throw new NotFoundDbException($"No se encontró el curso con ID {id}.");
            }

            return new Response<CursoResponseDTO>
            {
                Message = "Curso obtenido exitosamente: ",
                Data = _mapper.Map<CursoResponseDTO>(curso),
                Success = true
            };
        }
        
        
        public async Task<Response<CursoResponseDTO>> CreateAsync(CursoCreatedDTO entity)
        {
            var cursoExists = await _cursoRepository.GetByNameAsync(entity.Nombre);
            if (cursoExists != null)
            {
                throw new EntityExistDbException($"El curso con el nombre '{entity.Nombre}' ya existe en la base de datos.");
            }

            Curso newCurso = _mapper.Map<Curso>(entity);

            newCurso = await _cursoRepository.CreateAsync(newCurso);

            return new Response<CursoResponseDTO>
            {
                Message = "Curso creado exitosamente: ",
                Data = _mapper.Map<CursoResponseDTO>(newCurso),
                Success = true
            };
        }


        public async Task<Response<CursoResponseDTO>> UpdateAsync(CursoUpdateDTO entity)
        {
            var cursoExists = await _cursoRepository.GetByIdAsync(entity.Id);
            if (cursoExists == null)
            {
                throw new NotFoundDbException($"No existe el curso con ID {entity.Id}.");
            }

            Curso updatedCurso = _mapper.Map<Curso>(entity);

            updatedCurso = await _cursoRepository.UpdateAsync(updatedCurso);
            
            return new Response<CursoResponseDTO>
            {
                Message = "Curso actualizado exitosamente: ",
                Data = _mapper.Map<CursoResponseDTO>(updatedCurso),
                Success = true
            };
        }
        
        
        public async Task<Response<bool>> DeleteAsync(int id)
        {
            var cursoExists = await _cursoRepository.GetByIdAsync(id);
            if (cursoExists == null)
            {
                throw new NotFoundDbException($"No existe el curso con ID {id}.");
            }

            cursoExists.Estado = false;

            await _cursoRepository.UpdateAsync(cursoExists);

            return new Response<bool>
            {
                Message = "Curso eliminado exitosamente.", 
                Data = true,
                Success = true
            };
        }



    }
}
