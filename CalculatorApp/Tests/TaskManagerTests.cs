using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp;

namespace Tests
{
    [TestFixture]
    public class TaskManagerTests
    {
        private TaskManager manager;

        [SetUp]
        public void Setup()
        {
            manager = new TaskManager();
        }

        [Test]
        public void AddTask_ValidTask_TaskAdded()
        {
            manager.AddTask("Buy milk");
            Assert.IsTrue(manager.HasTask("Buy milk"));
        }

        [Test]
        public void AddTask_EmptyTask_ThrowsException()
        {
            Assert.Throws<ArgumentException>(() => manager.AddTask(""));
        }

        [Test]
        public void RemoveTask_ExistingTask_ReturnsTrue()
        {
            manager.AddTask("Buy milk");
            bool result = manager.RemoveTask("Buy milk");
            Assert.IsTrue(result);
            Assert.IsFalse(manager.HasTask("Buy milk"));
        }

        [Test]
        public void RemoveTask_NonExistingTask_ReturnsFalse()
        {
            bool result = manager.RemoveTask("Do homework");
            Assert.IsFalse(result);
        }

        [Test]
        public void GetAllTasks_ReturnsCopyOfTasks()
        {
            manager.AddTask("Task1");
            manager.AddTask("Task2");
            List<string> tasks = manager.GetAllTasks();

            Assert.AreEqual(2, tasks.Count);
            Assert.Contains("Task1", tasks);
            Assert.Contains("Task2", tasks);

  
            tasks.Remove("Task1");
            Assert.IsTrue(manager.HasTask("Task1"));
        }
    }
}
