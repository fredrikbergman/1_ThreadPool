using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace ThreadPoolExample
{
    class Fibonacci
    {
        private int _n;
        private int _fibOfN;
        private ManualResetEvent _doneEvent;

        public int N { get { return _n; } }
        public int FibOfN { get { return _fibOfN; } }

        public Fibonacci(int n, ManualResetEvent doneEvent)
        {
            _n = n;
            _doneEvent = doneEvent;
        }

        public void ThreadPoolCallback(object threadContext)
        {
            int threadIndex = (int)threadContext;
            Console.WriteLine("Thread {0} started..", threadIndex);
            _fibOfN = Calculate(_n);
            Console.WriteLine("Thread {0} result calculated..", threadIndex);
            _doneEvent.Set();
        }

        private int Calculate(int n)
        {
            if (n <= 1)
            {
                return n;
            }

            return Calculate(n - 1) + Calculate(n - 2);
        }
    }
}
