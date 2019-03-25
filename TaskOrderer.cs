using System;
namespace DS_CSHARP
{
    public class TaskOrderer
    {
        private TaskOrderer()
        {
        }

        public void Order(Task[] tasks)
        {

            Func<Task, int> taskToStart =  task => task.StartTime;
            Func<Task, int> taskToDur = task => task.Dur;
            Heap<int, Task> Starts = Heap<int, Task>.Heapify(tasks,taskToStart);
            Heap<int, Task> Durs = new Heap<int, Task>(tasks.Length, taskToDur);
            while (!Starts.IsEmpty || !Durs.IsEmpty)
            {
                do
                {
                    Durs.Insert(Starts.Root);
                } 
                while (Starts.RemoveMin().StartTime == Starts.Root.StartTime);
                Durs.Root.Begin();
                Durs.Root.Dur = Durs.Root.Dur - Durs.Root.StartTime + Starts.Root.StartTime;
                Durs.Root.Stop();
                if (Durs.Root.Dur == 0)
                {
                    Durs.RemoveMin();
                    Durs.Root.End();
                }
            }
        }
    }
    public class Task
    {
        public Task(int dur, int start)
        {
            Dur = dur;
            StartTime = start;
        }
        public int Dur { get; set; }
        public int StartTime { get; private set; }
        public void Begin(){ }
        public void Stop(){ }
        public void End(){ }
    }

}
