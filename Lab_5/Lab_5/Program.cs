using System;

namespace Lab_5
{
    class Program
    {
        static void Main(string[] args)
        {
            //https://dirask.com/snippets/cs/C%23+event+example
            Console.WriteLine("Hello World!");

            Couter couter = new Couter();

            couter.Changed += (object sender, ChangedEventArgs e) => // <----------- handled event
            {
                Console.WriteLine("Changed event occured: value=" + e.Value);
            };

            couter.Add(+1);
            couter.Add(+1);
            couter.Add(+1);

            couter.Add(-1);
            couter.Add(-1);
            couter.Add(-1);
        }
    }

    public class Couter
    {
        private int value;

        public event EventHandler<ChangedEventArgs> Changed; // <------------------- event declaration

        protected virtual void OnChanged(ChangedEventArgs e) // <------------------- wraps event (allows to raise the event)
        {
            EventHandler<ChangedEventArgs> handler = this.Changed;

            if (handler != null)
                handler(this, e);
        }

        public void Add(int step)
        {
            this.value += step;

            this.OnChanged(new ChangedEventArgs(this.value)); // <------------------- runs the event
        }
    }

    public class ChangedEventArgs : EventArgs
    {
        public int Value { get; set; }

        public ChangedEventArgs(int value)
        {
            this.Value = value;
        }
    }

    public class ObservableList1<T>
    {
        public void Add()
        {

        }

        public void Get()
        {

        }

        public void Set()
        {

        }

        public void RemoveAt()
        {

        }
    }
}
