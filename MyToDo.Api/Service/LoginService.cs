using Arch.EntityFrameworkCore.UnitOfWork;
using AutoMapper;
using MyToDo.Api.Context;
using MyToDo.Api.Service.IService;
using MyToDo.Shared.Dtos;

namespace MyToDo.Api.Service
{
    public class LoginService : ILoginService
    {
        private readonly IUnitOfWork work;
        private readonly IMapper mapper;

        public LoginService(IUnitOfWork work, IMapper mapper)
        {
            this.work = work;
            this.mapper = mapper;
        }
        public async Task<ApiResponse> LoginAsync(string account, string password)
        {
            try
            {
                User model = await work.GetRepository<User>().GetFirstOrDefaultAsync(predicate:
                    x => x.Account == account
                    &&
                    x.Password == password
                    );
                if (model == null)
                    return new ApiResponse(false, "账号或密码错误，请重试");
                return new ApiResponse(true, model);                
                
            }
            catch (Exception ex)
            {
                return new ApiResponse(false, ex.Message);
                throw;
            }
        }
        
        public async Task<ApiResponse> Register(UserDto user)
        {
            try
            {
                User model = mapper.Map<User>(user);
                var repository = work.GetRepository<User>();
                var u = await repository.GetFirstOrDefaultAsync(predicate:x => x.Account == model.Account);
                if (u != null)
                    return new ApiResponse(false, $"当前账号：{u.Account}已存在，请重新注册");
                await repository.InsertAsync(model);
                if (await work.SaveChangesAsync() > 0)
                    return new ApiResponse(true, model);
                return new ApiResponse(false, "注册失败");
            }
            catch (Exception ex)
            {
                return new ApiResponse(false, $"注册失败异常信息：{ex.Message}");
                throw;
            }
        }
    }
}
