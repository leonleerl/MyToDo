﻿using Arch.EntityFrameworkCore.UnitOfWork;
using AutoMapper;
using MyToDo.Api.Context;
using MyToDo.Api.Service.IService;
using MyToDo.Shared.Dtos;
using MyToDo.Shared.Parameters;

namespace MyToDo.Api.Service
{
    public class ToDoService : IToDoService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public ToDoService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<ApiResponse> AddAsync(ToDoDto model)
        {
            try
            {
                ToDo todo = mapper.Map<ToDo>(model);
                await unitOfWork.GetRepository<ToDo>().InsertAsync(todo);
                if (await unitOfWork.SaveChangesAsync() > 0)
                    return new ApiResponse(true, model);
                return new ApiResponse(false, "添加数据失败");
            }
            catch (Exception ex)
            {
                return new ApiResponse(ex.Message);
            }
        }

        public async Task<ApiResponse> DeleteByIdAsync(string id)
        {
            try
            {
                var repository = unitOfWork.GetRepository<ToDoDto>();
                var todo = await repository.GetFirstOrDefaultAsync(predicate: p => p.Id == id);
                repository.Delete(todo);
                if (await unitOfWork.SaveChangesAsync() > 0)
                    return new ApiResponse(true, "删除成功");
                return new ApiResponse(false, "删除数据失败");
            }
            catch (Exception ex)
            {
                return new ApiResponse(ex.Message);
            }
        }

        public async Task<ApiResponse> GetAllAsync(QueryParameter queryParameter)
        {
            try
            {
                var repository = unitOfWork.GetRepository<ToDo>();
                var todos = await repository.GetPagedListAsync(
                    predicate: p => string.IsNullOrWhiteSpace(queryParameter.Search) ? true : p.Title == queryParameter.Search,
                    pageIndex: queryParameter.PageIndex,
                    pageSize: queryParameter.PageSize,
                    orderBy: source => source.OrderByDescending(t => t.CreateDate));
                return new ApiResponse(true, todos);
            }
            catch (Exception ex)
            {
                return new ApiResponse(ex.Message);
            }
        }

        public async Task<ApiResponse> GetByIdAsync(string id)
        {
            try
            {
                var repository = unitOfWork.GetRepository<ToDo>();
                var result = await repository.GetFirstOrDefaultAsync(predicate: p => p.Id == id);
                if (result != null)
                    return new ApiResponse(true, result);
                return new ApiResponse(false, "未找到该数据");
            }
            catch (Exception ex)
            {
                return new ApiResponse(false, ex.Message);
                throw;
            }
        }

        public async Task<ApiResponse> UpdateAsync(ToDoDto model)
        {
            try
            {
                if (model == null)
                {
                    return new ApiResponse(false, "未找到该数据");
                }
                //ToDo toDo = mapper.Map<ToDo>(model);
                //var repository = unitOfWork.GetRepository<ToDoDto>();
                //ToDo result = await repository.GetFirstOrDefaultAsync(predicate: p => p.Id == toDo.Id);
                ToDo dbToDo = mapper.Map<ToDo>(model);
                var repository = unitOfWork.GetRepository<ToDo>();
                ToDo todo = await repository.GetFirstOrDefaultAsync(predicate: x => x.Id == dbToDo.Id);

                todo.Title = dbToDo.Title;
                todo.UpdateDate = DateTime.Now;
                todo.Content = dbToDo.Content;
                todo.Status = dbToDo.Status;
                repository.Update(todo);
                if (await unitOfWork.SaveChangesAsync() > 0)
                    return new ApiResponse(true, todo);
                return new ApiResponse(false, "保存数据出错");

            }
            catch (Exception ex)
            {
                return new ApiResponse(false, ex.Message);
                throw;
            }
        }
    }
}
