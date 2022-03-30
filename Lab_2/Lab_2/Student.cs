using System;
using System.Collections.Generic;
using System.Text;

namespace Lab_2
{
    class Student : Person
    {
        private string group;
        List<Task> tasks = new List<Task>();

        public string Group { get => group; }

        public Student(string name, int age, string group) : base(name, age)
        {
            this.group = group;
        }

        public Student (string name, int age, string group, List<Task> tasks) : base(name, age)
        {
            this.group = group;
            this.tasks = tasks;
        }
        

        public void AddTask(string TaskName, TaskStatus taskStatus)
        {
            tasks.Add(new Task(TaskName, taskStatus));
        }

        public void RemoveTask(int index)
        {
            tasks.RemoveAt(index);
        }

        public void UpdateTask(int index, TaskStatus taskStatus)
        {
            tasks[index].Status = taskStatus;
        }

        public string RenderTask(string prefix = "\t")
        {
            string value = "";
            foreach (Task t in tasks)
            {
                value += $"{prefix}{tasks.IndexOf(t) + 1}{t}";
            }

            return value;
        }

        public override string ToString()
        {
            string student = $"Student: {Name} ({Age} y.o.)\n";
            student += $"Group: {Group}\n";
            student += $"Tasks: {RenderTask("\n\t")}";

            return student;
        }

        public bool Equals(Student other)
        {
            return this.Name == other.Name && this.Age == other.Age ? true : false;
        }

        public bool SequenceEqual(List<Task> a,List<Task> b)
        {
            return a == b ? true : false;
        }

    }
}
