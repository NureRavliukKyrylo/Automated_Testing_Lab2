using System;
using System.Collections.Generic;
using System.Linq;

namespace ToDoApp
{
    public class TaskManager
    {
        private readonly List<string> tasks = new List<string>();

        public void AddTask(string task)
        {
            if (string.IsNullOrWhiteSpace(task))
                throw new ArgumentException("Task cannot be empty");
            tasks.Add(task);
        }

        public bool RemoveTask(string task)
        {
            return tasks.Remove(task);
        }

        public List<string> GetAllTasks()
        {
            return tasks.ToList(); 
        }

        public bool HasTask(string task)
        {
            return tasks.Contains(task);
        }
    }
}

