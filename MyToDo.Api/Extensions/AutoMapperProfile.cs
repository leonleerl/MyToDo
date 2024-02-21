using AutoMapper;
using AutoMapper.Configuration;
using MyToDo.Api.Context;
using MyToDo.Shared.Dtos;

namespace MyToDo.Api.Extensions
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<ToDoDto, ToDo>();
            CreateMap<MemoDto, Memo>();
        }
    }
}
