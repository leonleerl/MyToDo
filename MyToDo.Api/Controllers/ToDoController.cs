﻿using Arch.EntityFrameworkCore.UnitOfWork;
using Microsoft.AspNetCore.Mvc;
using MyToDo.Api.Context;
using MyToDo.Api.Service;
using MyToDo.Api.Service.IService;
using MyToDo.Shared.Dtos;
using MyToDo.Shared.Parameters;
using System.Formats.Asn1;

namespace MyToDo.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class ToDoController : Controller
    {
        private readonly IToDoService service;

        public ToDoController(IToDoService service)
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
        public async Task<ApiResponse> Add([FromBody] ToDoDto model)
        {
            return await service.AddAsync(model);
        }

        [HttpPost]
        public async Task<ApiResponse> Update([FromBody] ToDoDto model)
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
