

using InstitutoApp.Common.Interfaces;
using InstitutoApp.Data;
using InstitutoApp.Entities;
using Microsoft.EntityFrameworkCore;

namespace InstitutoApp.Repository
{
    public class MatriculaRepository : IGenericRepository<Matricula>
    {
        private readonly ApplicationDbContex _contex;

        public MatriculaRepository(ApplicationDbContex contex)
        {
            _contex = contex;
        }



        public async Task<List<Matricula>> GetAllAsync()
        {
            return await _contex.Matriculas
                .AsNoTracking()
                .Where(m => m.Estado == true)
                .Include(m => m.Estudiante)
                .Include(m => m.Curso)
                .ToListAsync();
        }


        public async Task<Matricula?> GetByIdAsync(int id)
        {
            return await _contex.Matriculas
                .AsNoTracking()
                .Where(m => m.Estado == true && m.Id == id)
                .Include(m => m.Estudiante)
                .Include(m => m.Curso)
                .SingleOrDefaultAsync();
        }


        public async Task<Matricula> CreateAsync(Matricula entity)
        {
            _contex.Matriculas.Add(entity);
            await _contex.SaveChangesAsync();
            return entity;
        }


        public async Task<Matricula> UpdateAsync(Matricula entity)
        {
            _contex.Matriculas.Update(entity);
            await _contex.SaveChangesAsync();
            return entity;
        }


        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }
    
    
    }
}
