using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoApi.Controllers;
using Microsoft.AspNetCore.Mvc;
using ToDoApi.Models;


namespace ToDoApi.Controllers
{
    [Route("api/[controller]")]
    public class TodoController : Controller
    {
        public TodoController(ITodoRepository todoItems)
        {
            TodoItems = todoItems;
        }

        public ITodoRepository TodoItems { get; private set; }

        [HttpGet]
        public IEnumerable<TodoItem> GetAll()
        {
            return TodoItems.GetAll();
        }


        [HttpGet("{id}", Name = "GetTodo")]
        public IActionResult GetById(string id)
        {
            var item = TodoItems.Find(id);
            if(item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }

    }
}
