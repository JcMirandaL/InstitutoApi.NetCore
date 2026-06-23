

using InstitutoApp.Common.Interfaces;
using InstitutoApp.Data;
using InstitutoApp.Entities;
using Microsoft.EntityFrameworkCore;

namespace InstitutoApp.Repository
{
    public class CursoRepository : IGenericRepository<Curso>
    {
        private readonly ApplicationDbContex _context;

        public CursoRepository(ApplicationDbContex context)
        {
            _context = context;
        }




        public async Task<List<Curso>> GetAllAsync()
        { 
            return await _context.Cursos
                .AsNoTracking()
                .Where(c => c.Estado == true)
                .ToListAsync();
        }


        public async Task<Curso?> GetByIdAsync(int id)
        {
            return await _context.Cursos
                .AsNoTracking()
                .Where(c => c.Id == id && c.Estado == true)
                .SingleOrDefaultAsync();
        }


        public async Task<Curso> CreateAsync(Curso entity)
        {
            _context.Cursos.Add(entity);
            await _context.SaveChangesAsync();
            return entity;

        }


        public async Task<Curso> UpdateAsync(Curso entity)
        {
            _context.Cursos.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }


        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }


        public async Task<Curso?> GetByNameAsync(string nombre)
        {
            return await _context.Cursos
                .AsNoTracking()
                .Where(c => c.Nombre == nombre && c.Estado == true)
                .SingleOrDefaultAsync();
        }
    

    }
}
