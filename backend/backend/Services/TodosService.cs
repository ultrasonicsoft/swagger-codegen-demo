using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using backend.ViewModels;
namespace backend.Services
{
    public class TodosService : ITodoService
    {
        List<TodoModel> allTodos;

        public TodosService()
        {
            allTodos = new List<TodoModel>
            {
                new TodoModel
                {
                    Id = 1,
                    Title = "Todo 1",
                    Description = "Test todo",
                    IsDone = false
                }
            };
        }

        public IEnumerable<TodoModel> GetAllTodos()
        {
            return allTodos;
        }
        public TodoModel GetTodoById(long id)
        {
            return allTodos.Find(x => x.Id == id);
        }
        public TodoModel CreateTodo(TodoModel todo)
        {
            allTodos.Add(todo);
            return todo;
        }
        public void UpdateTodo(long id, TodoModel todo)
        {
            var existingTodoIndex = allTodos.FindIndex(x => x.Id == id);
            allTodos[existingTodoIndex] = todo;
        }
        public void RemoveTodo(TodoModel todo)
        {
            allTodos.Remove(todo);
        }
        public void RemoveTodoById(long id)
        {
            var existingTodoIndex = allTodos.FindIndex(x => x.Id == id);
            allTodos.RemoveAt(existingTodoIndex);
        }
    }
}
