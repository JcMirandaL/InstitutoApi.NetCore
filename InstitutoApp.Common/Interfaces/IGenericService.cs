using InstitutoApp.Common.Response;


namespace InstitutoApp.Common.Interfaces
{
    public interface IGenericService <TResponse, TCreate, TUpdate>
    {
        Task<Response<List<TResponse>>> GetAllAsync();

        Task<Response<TResponse>> GetByIdAsync(int id);

        Task<Response<TResponse>> CreateAsync(TCreate entity);

        Task<Response<TResponse>> UpdateAsync(TUpdate entity);

        //este en vez de E va bool para que debuelva un boleano si se elimino o no el producto
        Task<Response<bool>> DeleteAsync(int id);
    }
}
