using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BobThreadPool
{
    class Job
    {
        WaitCallback function;
        object parameter;
        public JobState State { get; private set; }

        public Job(WaitCallback ts, object p = null)
        {
            function = ts;
            this.parameter = p;
            State = JobState.Waiting;
        }

        public void Run()
        {
            State = JobState.Working;
            function(parameter);
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
