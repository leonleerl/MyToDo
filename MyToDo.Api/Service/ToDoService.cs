using Arch.EntityFrameworkCore.UnitOfWork;
using MyToDo.Api.Context;
using MyToDo.Api.Service.IService;

namespace MyToDo.Api.Service
{
    public class ToDoService : IToDoService
    {
        private readonly IUnitOfWork unitOfWork;

        public ToDoService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }


        public async Task<ApiResponse> AddAsync(ToDo model)
        {
            try
            {
                await unitOfWork.GetRepository<ToDo>().InsertAsync(model);
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
                var repository = unitOfWork.GetRepository<ToDo>();
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

        public async Task<ApiResponse> GetAllAsync()
        {
            try
            {
                var repository = unitOfWork.GetRepository<ToDo>();
                var todos = await repository.GetAllAsync();
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

        public async Task<ApiResponse> UpdateAsync(ToDo model)
        {
            try
            {
                var repository = unitOfWork.GetRepository<ToDo>();
                var result = await repository.GetFirstOrDefaultAsync(predicate: p => p.Id == model.Id);
                if (result == null)
                {
                    return new ApiResponse(false, "未找到该数据");
                }
                result.Title = model.Title;
                result.UpdateDate = DateTime.Now;
                result.Content = model.Content;
                result.Status = model.Status;
                repository.Update(result);
                if (await unitOfWork.SaveChangesAsync()> 0)
                    return new ApiResponse(true, result);
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
