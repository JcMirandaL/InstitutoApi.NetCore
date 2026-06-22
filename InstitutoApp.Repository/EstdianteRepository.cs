using InstitutoApp.Common.Interfaces;
using InstitutoApp.Entities;

namespace InstitutoApp.Repository
{
    public class EstdianteRepository : IGenericRepository<Estudiante>
    {

        public Task<List<Estudiante>> GetAllAsync()
        {
            throw new NotImplementedException();
        }
        

        public Task<Estudiante?> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
        
        
        public Task<Estudiante> CreateAsync(Estudiante entity)
        {
            throw new NotImplementedException();
        }
        
        
        public Task<Estudiante> UpdateAsync(Estudiante entity)
        {
            throw new NotImplementedException();
        }


        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

    }
}
