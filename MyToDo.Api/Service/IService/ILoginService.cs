using MyToDo.Api.Context;
using MyToDo.Shared.Dtos;

namespace MyToDo.Api.Service.IService
{
    public interface ILoginService
    {
        Task<ApiResponse> LoginAsync(string account, string password);
        Task<ApiResponse> Register(UserDto user);
    }
}
