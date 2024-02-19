using MyToDo.Api.Context;

namespace MyToDo.Api.Repository.Interface
{
    public interface IToDoRepository
    {
        Task<bool> Add(ToDo toDo);
        Task<bool> Update(ToDo toDo);
        Task<bool> Delete(string Id);
    }
}
