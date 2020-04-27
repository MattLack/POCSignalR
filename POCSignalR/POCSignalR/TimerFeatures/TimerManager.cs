using System;
using System.Threading;

namespace POCSignalR.TimerFeatures
{
    public class TimerManager
    {
        private readonly Action _action;
        private readonly AutoResetEvent _autoResetEvent;
        private readonly Timer _timer;

        public TimerManager(Action action)
        {
            _action = action;
            _autoResetEvent = new AutoResetEvent(false);
            _timer = new Timer(Execute, _autoResetEvent, 1000, 2000);
            TimerStarted = DateTime.Now;
        }

        public DateTime TimerStarted { get; }


        public void Execute(object stateInfo)
        {
            _action();

            //dispose timer after 60 seconds
            if ((DateTime.Now - TimerStarted).Seconds > 60) _timer.Dispose();
        }
    }
}