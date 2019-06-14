using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using backend.ViewModels;
namespace backend.Services
{
    public interface ITodoService
    {
        IEnumerable<TodoModel> GetAllTodos();
        TodoModel GetTodoById(long id);
        TodoModel CreateTodo(TodoModel todo);
        void UpdateTodo(long id, TodoModel todo);
        void RemoveTodo(TodoModel todo);
        void RemoveTodoById(long id);
    }
}
