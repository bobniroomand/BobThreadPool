using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BobThreadPool
{
    public class ThreadPool
    {
        private Queue<Task> tasks;
        private Queue<Task> runningTasks;
        private List<Thread> threads;

        public ThreadPool(int size = 10)
        {
            tasks = new Queue<Task>();
            threads = new List<Thread>();
            //in vase teste
            for (int i = 0; i < size; i++)
            {
                Thread newThread = new Thread(WaitForTask);
                threads.Add(newThread);
                newThread.Start();
            }
        }

        private void WaitForTask()
        {
            //TODO wait for task queue to get item from it
            while (true)
            {
                lock (tasks)
                {
                    if (tasks.Count != 0)
                    {
                        //TODO do the task's job!
                        Task t = tasks.Dequeue();
                        t.Start();
                    }
                }
            }
        }
    }
}
