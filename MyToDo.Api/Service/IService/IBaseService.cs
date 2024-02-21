using MyToDo.Shared.Parameters;

namespace MyToDo.Api.Service.IService
{
    public interface IBaseService<T>
    {
        Task<ApiResponse> GetAllAsync(QueryParameter queryParameter);
        Task<ApiResponse> GetByIdAsync(string id);
        Task<ApiResponse> AddAsync(T model);
        Task<ApiResponse> UpdateAsync(T model);
        Task<ApiResponse> DeleteByIdAsync(string id);
    }
}
