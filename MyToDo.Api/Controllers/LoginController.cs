using Microsoft.AspNetCore.Mvc;
using MyToDo.Api.Service.IService;
using MyToDo.Api.Service;
using MyToDo.Shared.Dtos;
using MyToDo.Shared.Parameters;

namespace MyToDo.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class LoginController : Controller
    {
        private readonly ILoginService service;

        public LoginController(ILoginService service)
        {
            this.service = service;
        }

        [HttpGet]
        public async Task<ApiResponse> Get(string account, string password)
        {
            return await service.LoginAsync(account, password);
        }

        [HttpPost]
        public async Task<ApiResponse> Register([FromQuery] UserDto queryParameter)
        {
            return await service.Register(queryParameter);
        }


    }
}
