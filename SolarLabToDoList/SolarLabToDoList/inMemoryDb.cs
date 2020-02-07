using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace SolarLabToDoList
{
    class inMemoryDb
    {
        private List<Task> TasksNew;
        private int number = 1;
        public inMemoryDb()
        {
            TasksNew = new List<Task>();
        }
        public void Add(Task t)
        {
            TasksNew.Add(t);
            t.Number = number;
            number++;
        }

        public void Remove(int id)
        {
            Task task = TasksNew.Where(t => t.Number == id).FirstOrDefault();
            TasksNew.Remove(task);
        }

        public List<Task> GetAll()
        {
            return TasksNew;
        }

        public Task GetById(int id)
        {
            Task task = TasksNew.Where(t => t.Number == id).Single();
            return task;
        }
    };
};
