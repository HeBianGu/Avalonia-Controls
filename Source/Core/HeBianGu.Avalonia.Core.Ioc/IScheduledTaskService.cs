﻿using System;

namespace HeBianGu.Avalonia.Core.Ioc
{
    public interface IScheduledTaskService
    {
        void Start();
        void Stop();
    }

    public abstract class ScheduledTaskServiceBase : IScheduledTaskService
    {
        private System.Timers.Timer _timer;
        public ScheduledTaskServiceBase()
        {

        }

        protected virtual int GetInterval() => 5000;

        public virtual void Start()
        {
            if (_timer != null && _timer.Enabled)
            {
                _timer.Elapsed -= Elapsed;
                _timer.Dispose();
            }
            _timer = new System.Timers.Timer();
            _timer.Interval = this.GetInterval();
            _timer.Elapsed += Elapsed;
            _timer.Start();
        }

        private void Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (this.Invoke(out string message) == false)
                IocLog.Instance?.Error(message);
        }

        public abstract bool Invoke(out string message);

        public virtual void Stop()
        {
            _timer?.Stop();
        }
    }
}
