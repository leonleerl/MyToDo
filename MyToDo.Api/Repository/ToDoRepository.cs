using MyToDo.Api.Context;
using MyToDo.Api.Repository.Interface;

namespace MyToDo.Api.Repository
{
    public class ToDoRepository : IToDoRepository
    {
        private MyToDoContext _context;
        public ToDoRepository(MyToDoContext context)
        {
            _context = context;
        }
        public async Task<bool> Add(ToDo toDo)
        {
            await _context.SaveChangesAsync();
            return await _context.SaveChangesAsync() > 0;
        }

        public Task<bool> Delete(string Id)
        {
            return null;
        }

        public Task<bool> Update(ToDo toDo)
        {
            return null;
        }
    }
}
