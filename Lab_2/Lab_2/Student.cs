using System;
using System.Collections.Generic;
using System.Text;

namespace Lab_2
{
    class Student : Person
    {
        string Group { get; set; }
        List<Task> Tasks = new List<Task>();

        public Student(string name, int age, string group) : base(name, age)
        {
            Group = group;
        }

        public Student (string name, int age, string group, List<Task> tasks) : base(name, age)
        {
            Group = group;
            Tasks = tasks;
        }
        

        public void AddTask(string TaskName, TaskStatus taskStatus)
        {
            Tasks.Add(new Task(TaskName, taskStatus));
        }

        public void RemoveTask(int index)
        {
            Tasks.RemoveAt(index);
        }

        public void UpdateTask(int index, TaskStatus taskStatus)
        {
            Tasks[index].Status = taskStatus;
        }

    }
}
