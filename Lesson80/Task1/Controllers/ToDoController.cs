using Microsoft.AspNetCore.Mvc;
using Task1.Model;

namespace Task1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ToDoController : ControllerBase
    {
        private static readonly List<ToDo> _toDos = [];
        private readonly ILogger<ToDoController> _logger;

        public ToDoController(ILogger<ToDoController> logger) => _logger = logger;

        [HttpGet]
        [Route("/GetAllTasks")]
        public IEnumerable<ToDo> Get()
        {
            return _toDos;
        }

        [HttpPost(Name = "AddToDo")]
        //[Route("/AddToDo")]
        public void Add(ToDo toDo)
        {
            _toDos.Add(toDo);
        }

        [HttpPut]
        [Route("/UpdateToDo")]
        public ActionResult<ToDo> Update(ToDo updatedToDo)
        {
            int index = _toDos.FindIndex(t => t.Id == updatedToDo.Id);
            _toDos[index] = updatedToDo;
            return Ok(_toDos[index]);
        }

        [HttpDelete(Name = "DeleteTodo")]
        //[Route("/DeleteToDo")]
        public void Delete(int id)
        {
            _toDos.Remove(_toDos.First(t => t.Id == id));
        }
    }
}
