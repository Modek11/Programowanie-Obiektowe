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
        public string Name { get; set; }
        public TaskStatus Status { get; set; }

        public Task(string name, TaskStatus status)
        {
            Name = name;
            Status = status;
        }

        public override string ToString()
        {
            return base.ToString();
        }

        bool Equals(Task other)
        {
            return Name == other.Name && Status == other.Status ? true : false;
        }

    }
}
