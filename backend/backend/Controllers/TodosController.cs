using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860
using backend.Services;
using backend.ViewModels;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    public class TodosController : Controller
    {
        private readonly ITodoService _service;

        public TodosController(ITodoService service)
        {
            this._service = service;
        }
        // GET: api/values
        [HttpGet]
        public IEnumerable<TodoModel> Get()
        {
            return _service.GetAllTodos();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public TodoModel Get(int id)
        {
            return _service.GetTodoById(id);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]TodoModel newTodo)
        {
            _service.CreateTodo(newTodo);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]TodoModel todo)
        {
            _service.UpdateTodo(id, todo);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _service.RemoveTodoById(id);
        }
    }
}
