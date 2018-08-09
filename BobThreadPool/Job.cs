using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BobThreadPool
{
    class Job
    {
        Action task;
        public JobState State { get; private set; }

        public Job(Action a)
        {
            task = a;
            State = JobState.Waiting;
        }

        public void Run()
        {
            State = JobState.Working;
            task();
            State = JobState.Terminated;
        }

    }

    enum JobState
    {
        Waiting,
        Working,
        Terminated
    }
}
