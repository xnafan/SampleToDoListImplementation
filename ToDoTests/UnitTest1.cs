using ToDoListClassLibrary;
using ToDoListDAL.InMemory;

namespace ToDoTests
{
    public class Tests
    {
        private InMemoryToDoListDao _toDoListDao = new();
        
        [SetUp]
        public void Setup()
        {
            _toDoListDao.Add(new ToDoItem("Brush your teeth"));
            _toDoListDao.Add(new ToDoItem("Mow the lawn"));
            _toDoListDao.Add(new ToDoItem("Write Valentine's card"));
        }

        [Test]
        public void AddAndFindAgain()
        {
            string taskName = "Task for test";
            //arrange
            //act
            var newId = _toDoListDao.Add(new ToDoItem(taskName));

            //assert
            Assert.That(taskName,Is.EqualTo(_toDoListDao.GetById(newId).Name), "The same task was not found");
        }
    }
}