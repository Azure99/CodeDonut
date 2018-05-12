using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Timers;

namespace CodeDonut.Judger
{
    class RuntimeMonitor : IDisposable
    {
        public long MemoryCost { get; set; }
        public int TimeCost { get; set; }
        public int TimeLimit { get; }
        public Process RunProcess { get; }

        private Timer _timer;
        public RuntimeMonitor(Process process, int timeLimit = 1000)
        {
            _timer = new Timer(10);
            RunProcess = process;
            TimeLimit = timeLimit;

            _timer.Elapsed += new ElapsedEventHandler(TimerElapsedEvent);
        }

        public void Start()
        {
            TimeCost = 0;
            MemoryCost = 0;
            _timer.Start();
        }

        public void Stop()
        {
            _timer.Stop();
        }

        private void TimerElapsedEvent(object sender, ElapsedEventArgs e)
        {
            try
            {
                if (!RunProcess.HasExited)
                {
                    int nowTimeCost = (int)(DateTime.Now - RunProcess.StartTime).TotalMilliseconds;
                    if (nowTimeCost > TimeCost)
                    {
                        TimeCost = nowTimeCost;

                        if (TimeCost > TimeLimit)
                        {
                            RunProcess.Kill();
                        }
                    }

                    long nowMemoryCost = RunProcess.PeakPagedMemorySize64 / 1024;

                    if (nowMemoryCost > MemoryCost)
                    {
                        MemoryCost = nowMemoryCost;
                    }
                }
            }
            catch { }
        }

        public void Dispose()
        {
            _timer.Stop();
            _timer.Dispose();
        }
    }
}
