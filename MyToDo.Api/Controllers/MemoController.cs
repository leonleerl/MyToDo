using Microsoft.AspNetCore.Mvc;
using MyToDo.Api.Service.IService;
using MyToDo.Api.Service;
using MyToDo.Shared.Dtos;
using MyToDo.Shared.Parameters;

namespace MyToDo.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class MemoController : Controller
    {
        private readonly IMemoService service;

        public MemoController(IMemoService service)
        {
            this.service = service;
        }

        [HttpGet]
        public async Task<ApiResponse> Get(string id)
        {
            return await service.GetByIdAsync(id);
        }

        [HttpGet]
        public async Task<ApiResponse> GetAll([FromQuery] QueryParameter queryParameter)
        {
            return await service.GetAllAsync(queryParameter);
        }

        [HttpPost]
        public async Task<ApiResponse> Add([FromBody] MemoDto model)
        {
            return await service.AddAsync(model);
        }

        [HttpPost]
        public async Task<ApiResponse> Update([FromBody] MemoDto model)
        {
            return await service.UpdateAsync(model);
        }

        [HttpDelete]
        public async Task<ApiResponse> Delete(string id)
        {
            return await service.DeleteByIdAsync(id);
        }


    }
}
