using System;
using System.Collections.Generic;
using System.Text;

namespace Lab_2
{
    enum TaskStatus
    {
        Waiting,
        Progress,
        Done,
        Rejected
    }
    class Task
    {
        private string name;
        private TaskStatus status;
        
        public string Name { get => name; }
        public TaskStatus Status { get => status; set => status = value; }

        public Task(string name, TaskStatus status)
        {
            this.name = name;
            this.status = status;
        }

        public override string ToString()
        {
            return base.ToString();
        }

        public bool Equals(Task other)
        {
            return Name == other.Name && Status == other.Status ? true : false;
        }

    }
}
