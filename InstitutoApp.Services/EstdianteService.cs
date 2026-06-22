using InstitutoApp.Common.Interfaces;
using InstitutoApp.Common.Response;
using InstitutoApp.DTOs.EstudianteDTOs;

namespace InstitutoApp.Services
{
    public class EstdianteService : IGenericService<EstudianteResponseDTO, EstudianteCreatedDTO, EstudianteUpdateDTO>
    {
        //injeccion dependencia hacia el repositorio





        public Task<Response<List<EstudianteResponseDTO>>> GetAllAsync()
        {
            throw new NotImplementedException();
        }
        

        public Task<Response<EstudianteResponseDTO>> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }


        public Task<Response<EstudianteResponseDTO>> CreateAsync(EstudianteCreatedDTO entity)
        {
            throw new NotImplementedException();
        }


        public Task<Response<EstudianteResponseDTO>> UpdateAsync(EstudianteUpdateDTO entity)
        {
            throw new NotImplementedException();
        }


        public Task<Response<bool>> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
