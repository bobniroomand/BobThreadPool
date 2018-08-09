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

        Job(Action a)
        {
            task = a;
            State = JobState.Waiting;
        }

        void Run()
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
