using InstitutoApp.Common.Interfaces;
using InstitutoApp.Data;
using InstitutoApp.Entities;
using Microsoft.EntityFrameworkCore;

namespace InstitutoApp.Repository
{
    public class EstdianteRepository : IGenericRepository<Estudiante>
    {
        private readonly ApplicationDbContex _contex;

        public EstdianteRepository(ApplicationDbContex contex)
        {
            _contex = contex;
        }




        public async Task<List<Estudiante>> GetAllAsync()
        {
            return await _contex.Estudiantes
                .AsNoTracking()
                .Where(e => e.Estado == true)
                .ToListAsync();
        }
        

        public async Task<Estudiante?> GetByIdAsync(string cedula)
        {
            return await _contex.Estudiantes
                .AsNoTracking()
                .Where(e => e.Cedula == cedula && e.Estado == true)
                .SingleOrDefaultAsync();
        }
        
        
        public async Task<Estudiante> CreateAsync(Estudiante entity)
        {
            _contex.Estudiantes.Add(entity);
            await _contex.SaveChangesAsync();
            return entity;
        }
        
        
        public async Task<Estudiante> UpdateAsync(Estudiante entity)
        {
            _contex.Estudiantes.Update(entity);
            await _contex.SaveChangesAsync();
            return entity;
        }




        public async Task<Estudiante?> GetByEmailAsync(string correo)
        {
            return await _contex.Estudiantes
                .AsNoTracking()
                .Where(e => e.Correo == correo && e.Estado == true)
                .SingleOrDefaultAsync();
        }


        //cumplir con IGenericRepository
        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }


        public Task<Estudiante?> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
