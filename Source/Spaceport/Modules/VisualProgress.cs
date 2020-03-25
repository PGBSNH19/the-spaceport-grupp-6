using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Spaceport
{
    class VisualProgress
    {
        private Timer t; 

        public void AwaitAndShow(Task[] task)
        {
            t = new Timer(DataWorkVisual, null, 0, 200);
            Task.WaitAll(task);
            t.Dispose();
        }
        
        internal void DataWorkVisual(object state)
        {
            Console.Write(".");
        }
    }
}
