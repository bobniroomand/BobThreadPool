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
        private Queue<Job> jobs;
        private Queue<Job> runningJobs;
        private List<Thread> threads;

        public ThreadPool(int size = 10)
        {
            jobs = new Queue<Job>();
            threads = new List<Thread>();
            for (int i = 0; i < size; i++)
            {
                Thread newThread = new Thread(WaitForTask);
                threads.Add(newThread);
                newThread.Start();
            }
        }

        public void EnqueueJob(WaitCallback ts, object param = null)
        {
            lock (jobs)
            {
                jobs.Enqueue(new Job(ts, param));
            }
        }

        public void CloseThreadPool(bool ignoreWaitingTasks)
        {
            if (ignoreWaitingTasks)
            {
                for (int i = 0; i < jobs.Count; i++)
                {
                    jobs.Dequeue();
                }

                for (int i = 0; i < threads.Count; i++)
                {
                    threads[i].Abort();
                }

            }
            //else
            //{
            //    new Thread(() => {
            //        while (true)
            //        {
            //            lock (jobs)
            //            {
            //                if (jobs.Count == 0)
            //                {
            //                    break;
            //                }
            //            }
            //        }
            //        while (true)
            //        {
            //            for (int i = 0; i < threads.Count; i++)
            //            {
            //                if(threads[i].)
            //            }
            //        }
            //    }).Start();
            //}
        }

        private void WaitForTask()
        {
            //TODO wait for task queue to get item from it
            while (true)
            {
                lock (jobs)
                {
                    if (jobs.Count != 0)
                    {
                        //TODO do the task's job!
                        Job j = jobs.Dequeue();
                        j.Run();
                    }
                }
            }
        }

    }
}
