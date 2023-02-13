using Microsoft.AspNetCore.Mvc;
using ToDoListClassLibrary;
using ToDoListDAL;
using ToDoListDAL.InMemory;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ToDoListWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoItemsController : ControllerBase
    {
        IToDoListDao _toDoListDao;
        public ToDoItemsController(IToDoListDao toDoListDao) => _toDoListDao = toDoListDao;

        [HttpGet]
        public IEnumerable<ToDoItem> Get() => _toDoListDao.GetAll();

        [HttpGet("{id}")]
        public ToDoItem Get(int id) => _toDoListDao.GetById(id);

        [HttpPost]
        public int Post([FromBody] ToDoItem itemToAdd) => _toDoListDao.Add(itemToAdd);

        // PUT api/<ToDoItemsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ToDoItemsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
