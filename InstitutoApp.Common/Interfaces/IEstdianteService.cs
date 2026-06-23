using InstitutoApp.Common.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstitutoApp.Common.Interfaces
{
    public interface IEstdianteService<TResponse, TCreate, TUpdate>
    {
        Task<Response<List<TResponse>>> GetAllAsync();

        Task<Response<TResponse>> GetByIdAsync(string cedula);

        Task<Response<TResponse>> CreateAsync(TCreate entity);
        
        Task<Response<TResponse>> UpdateAsync(TUpdate entity);
        
        Task<Response<bool>> DeleteAsync(string cedula);

    }
}
