using Arch.EntityFrameworkCore.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using MyToDo.Api.Context;
using MyToDo.Api.Repository;
using MyToDo.Api.Service;
using MyToDo.Api.Service.IService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<MyToDoContext>(configure =>
{
    configure.UseSqlite(builder.Configuration.GetConnectionString("ToDoConnection"));
}).AddUnitOfWork<MyToDoContext>()
.AddCustomRepository<ToDo, ToDoRepository>()
.AddCustomRepository<Memo, MemoRepository>()
.AddCustomRepository<User, UserRepository>();
builder.Services.AddTransient<IToDoService, ToDoService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
